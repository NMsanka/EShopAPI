using System;

namespace EShop.Log
{
    public interface ILogger
    {
        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(object message);

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(string message);

        /// <summary>
        /// Errors the specified exception to log.
        /// </summary>
        /// <param name="exceptionToLog">The exception to log.</param>
        void Error(Exception exceptionToLog);

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Error(object message, Exception exception);

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(object message);

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Warning(object message);

        /// <summary>
        /// Fatals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Fatal(string message);

        /// <summary>
        /// Fatals the specified exception to log.
        /// </summary>
        /// <param name="exceptionToLog">The exception to log.</param>
        void Fatal(Exception exceptionToLog);

        /// <summary>
        /// Fatals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exceptionToLog">The exception to log.</param>
        void Fatal(object message, Exception exceptionToLog);
    }
}
