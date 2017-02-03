using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.Extensions.PlatformAbstractions;
using Collection.API.Infrastructure;
using Collection.API.Repositories.Interfaces;
using Collection.API.Repositories;
using Collection.API.Services.Interfaces;
using Collection.API.Services;
using Collection.API.Factories;
using Collection.API.Factories.Interfaces;

namespace Collection.API
{
    /// <summary>
    /// Application entry point
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Gets or sets the automatic mapper configuration.
        /// </summary>
        private MapperConfiguration AutoMapperConfig { get; set; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">The environment</param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            this.AutoMapperConfig = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfileConfiguration()));

            builder.AddUserSecrets();

            builder.AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddMvc();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddApiVersioning();
            services.AddSwaggerGen(options =>
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                options.SingleApiVersion(new Swashbuckle.Swagger.Model.Info
                {
                    Version = "v1",
                    Title = this.Configuration["SwaggerInfo:Title"],
                    Description = this.Configuration["SwaggerInfo:Description"]
                });
                options.IncludeXmlComments($"{basePath}\\Collection.API.xml");
                options.DescribeAllEnumsAsStrings();
            });

            services.AddSingleton<IDbConnectionFactory>(x => new DbConnectionFactory(this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton(x => this.AutoMapperConfig.CreateMapper());

            services.AddScoped(x => x.GetService<IDbConnectionFactory>().GetOpenConnection());

            services.AddTransient<IMoviesRepository, MoviesRepository>();
            services.AddTransient<IMoviesService, MoviesService>();

        }

        /// <summary>
        /// Configures the application
        /// </summary>
        /// <param name="app">The application</param>
        /// <param name="env">The environment</param>
        /// <param name="loggerFactory">The logger factory</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (!env.IsProduction())
            {
                loggerFactory.AddDebug();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
