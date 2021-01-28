// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Reciever.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace MSMQ
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Experimental.System.Messaging;

    /// <summary>
    /// Reciver class
    /// </summary>
    public class Reciver
    {
        /// <summary>
        /// Recive this instance.
        /// </summary>
        /// <returns>link to be send</returns>
        public string Recive()
        {
            var reciever = new MessageQueue(@".\Private$\MyQueue");
            var recieving = reciever.Receive();
            recieving.Formatter = new BinaryMessageFormatter();
            string linkToBeSend = recieving.Body.ToString();
            return linkToBeSend;
        }
    }
}
