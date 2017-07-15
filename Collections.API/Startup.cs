using AutoMapper;
using Collections.API.Factories;
using Collections.API.Factories.Interfaces;
using Collections.API.Mappings.Profiles;
using Collections.API.Repositories;
using Collections.API.Repositories.Interfaces;
using Collections.API.Services;
using Collections.API.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using NLog.Extensions.Logging;

namespace Collections.API
{
    /// <summary>
    /// Startup Class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Gets or sets the Auto mapper configuration
        /// </summary>
        private MapperConfiguration AutoMapperConfig { get; set; }

        /// <summary>
        /// Gets the configuration
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
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            this.AutoMapperConfig = new MapperConfiguration(
                                        x =>
                                        {
                                            x.AddProfile(new AlbumsProfile());
                                            x.AddProfile(new MoviesProfile());
                                            x.AddProfile(new BooksProfile());
                                            x.AddProfile(new VideoGamesProfile());
                                        });

            builder.AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        /// <summary>
        /// Configures the services the application needs
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddMvc();
            services.AddRouting(options => options.LowercaseUrls = true);

            // Swagger config, adds support for multiple concurrent documentation one per version.
            services.AddSwaggerGen(options =>
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                options.MultipleApiVersions(new Swashbuckle.Swagger.Model.Info[]
                {
                    // New API versions should be added as models similar to the one below
                    new Swashbuckle.Swagger.Model.Info
                    {
                        Version = "v1",
                        Title = this.Configuration["SwaggerInfo:Title"],
                        Description = this.Configuration["SwaggerInfo:Description"],
                        Contact = new Swashbuckle.Swagger.Model.Contact
                        {
                            Name = this.Configuration["SwaggerInfo:Contact:Name"]
                        }
                    }
                }, (description, version) =>
                {
                    return description.RelativePath.Contains($"api/{version}");
                });

                options.IncludeXmlComments($"{basePath}\\Collections.API.xml");
                options.DescribeAllEnumsAsStrings();
                options.GroupActionsBy(c => c.GroupName);
            });

            services.AddSingleton(x => this.AutoMapperConfig.CreateMapper());

            services.AddSingleton<IMongoDbFactory>(x => new MongoDbFactory(this.Configuration["ConnectionString:DefaultConnection"], this.Configuration["AppSettings:CollectionName"]));
            services.AddSingleton(this.Configuration);

            services.Configure<AppSettings>(this.Configuration.GetSection("AppSettings"));
            services.AddScoped(x => x.GetService<IOptionsSnapshot<AppSettings>>().Value);

            services.AddTransient<ICollectionService, CollectionService>();
            services.AddTransient<ICollectionRepository, CollectionRepository>();
            services.AddTransient<IDataRepository, MongoDbDataRepository>();
        }

        /// <summary>
        /// Configures the specified application itself.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The environment</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                loggerFactory.AddDebug();
            }

            loggerFactory.AddNLog();
            loggerFactory.ConfigureNLog($"{basePath}\\nlog.config");

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
