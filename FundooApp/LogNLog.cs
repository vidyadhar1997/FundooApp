// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogNLog.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooApp
{
    using FundooManager.Interface;
    using NLog;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// LogNLog class
    /// </summary>
    /// <seealso cref="FundooManager.Interface.ILog" />
    public class LogNLog : ILog
    {
        /// <summary>
        /// The logger
        /// </summary>
        /// 
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Information(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warning(string message)
        {
            logger.Warn(message);
        }
    }
}
