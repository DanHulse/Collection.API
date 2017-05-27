using System;
using log4net;
using log4net.Repository;
using Collections.API.Enumerations;
using Collections.API.Infrastructure.Interfaces;

namespace Collections.API.Infrastructure
{
    /// <summary>
    /// Implementation of Log 4 Net
    /// </summary>
    /// <seealso cref="Collections.API.Infrastructure.Interfaces.ILogger" />
    public class Logger : ILogger
    {
        /// <summary>
        /// Log 4 Net instance.
        /// </summary>
        private readonly ILog log;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger()
        {
            this.log = LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Assembly,
                "serverLog");
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Logger"/> class. Excepting a log 4 net instance.
        /// </summary>
        /// <param name="log">Log4Net Instance.</param>
        public Logger(ILog log)
        {
            this.log = log;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the repository.
        /// </summary>
        public ILoggerRepository Repository
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Check if the level is enabled.
        /// </summary>
        /// <param name="level">The log level to check.</param>
        /// <returns>True or false.</returns>
        public bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return this.log.IsDebugEnabled;
                case LogLevel.Information:
                    return this.log.IsInfoEnabled;
                case LogLevel.Warning:
                    return this.log.IsWarnEnabled;
                case LogLevel.Error:
                    return this.log.IsErrorEnabled;
                case LogLevel.Fatal:
                    return this.log.IsFatalEnabled;
            }

            return false;
        }

        /// <summary>
        /// Log message at specified log level.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="exception">The exception that was thrown to log.</param>
        /// <param name="message">The message to log.</param>
        public virtual void Log(LogLevel level, Exception exception, string message)
        {
            this.Log(level, exception, message, null);
        }

        /// <summary>
        /// Log message at specified log level.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="exception">The exception that was thrown to log.</param>
        public virtual void Log(LogLevel level, Exception exception)
        {
            this.Log(level, exception);
        }

        /// <summary>
        /// Log formatted message at specified log level .
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="exception">The exception that was thrown to log.</param>
        /// <param name="format">The composite format message to log.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public virtual void Log(LogLevel level, Exception exception, string format, params object[] args)
        {
            if (args == null)
            {
                switch (level)
                {
                    case LogLevel.Debug:
                        this.log.Debug(format, exception);
                        break;
                    case LogLevel.Information:
                        this.log.Info(format, exception);
                        break;
                    case LogLevel.Warning:
                        this.log.Warn(format, exception);
                        break;
                    case LogLevel.Error:
                        this.log.Error(format, exception);
                        break;
                    case LogLevel.Fatal:
                        this.log.Fatal(format, exception);
                        break;
                }
            }
            else
            {
                switch (level)
                {
                    case LogLevel.Debug:
                        this.log.DebugFormat(format, exception, args);
                        break;
                    case LogLevel.Information:
                        this.log.InfoFormat(format, exception, args);
                        break;
                    case LogLevel.Warning:
                        this.log.WarnFormat(format, exception, args);
                        break;
                    case LogLevel.Error:
                        this.log.ErrorFormat(format, exception, args);
                        break;
                    case LogLevel.Fatal:
                        this.log.FatalFormat(format, exception, args);
                        break;
                }
            }
        }

        /// <summary>
        /// Log message at specified log level.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="message">The message to log.</param>
        public virtual void Log(LogLevel level, string message)
        {
            this.Log(level, message, null);
        }

        /// <summary>
        /// Log formatted message at specified log level. 
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="format">The composite format message to log.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public virtual void Log(LogLevel level, string format, params object[] args)
        {
            if (args == null)
            {
                switch (level)
                {
                    case LogLevel.Debug:
                        this.log.Debug(format);
                        break;
                    case LogLevel.Information:
                        this.log.Info(format);
                        break;
                    case LogLevel.Warning:
                        this.log.Warn(format);
                        break;
                    case LogLevel.Error:
                        this.log.Error(format);
                        break;
                    case LogLevel.Fatal:
                        this.log.Fatal(format);
                        break;
                }
            }
            else
            {
                switch (level)
                {
                    case LogLevel.Debug:
                        this.log.DebugFormat(format, args);
                        break;
                    case LogLevel.Information:
                        this.log.InfoFormat(format, args);
                        break;
                    case LogLevel.Warning:
                        this.log.WarnFormat(format, args);
                        break;
                    case LogLevel.Error:
                        this.log.ErrorFormat(format, args);
                        break;
                    case LogLevel.Fatal:
                        this.log.FatalFormat(format, args);
                        break;
                }
            }
        }
    }
}