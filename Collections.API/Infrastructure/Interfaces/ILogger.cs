using System;
using Collections.API.Enumerations;

namespace Collections.API.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface for the Logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Check if the level is enabled.
        /// </summary>
        /// <param name="level">The log level to check.</param>
        /// <returns>true or false.</returns>
        bool IsEnabled(LogLevel level);

        /// <summary>
        /// Log message at specified log level.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="exception">The exception that was thrown to log.</param>
        /// <param name="message">The message to log.</param>
        void Log(LogLevel level, Exception exception, string message);

        /// <summary>
        /// Log formatted message at specified log level.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="exception">The exception that was thrown to log.</param>
        /// <param name="format">The composite format message to log.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Log(LogLevel level, Exception exception, string format, params object[] args);

        /// <summary>
        /// Log message at specified log level.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="message">The message to log.</param>
        void Log(LogLevel level, string message);

        /// <summary>
        /// Log formatted message at specified log level.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="format">The composite format message to log.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Log(LogLevel level, string format, params object[] args);
    }
}
