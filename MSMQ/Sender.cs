// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sender.cs" company="Bridgelabz">
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
    /// Sender class 
    /// </summary>
    public class Sender
    {
        /// <summary>
        /// Sends this instance.
        /// </summary>
        public void Send()
        {
            var url = "https://www.codeproject.com/Articles/165576/Use-of-MSMQ-for-Sending-Bulk-Mails";
            MessageQueue msmqQueue;
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                msmqQueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                msmqQueue = MessageQueue.Create(@".\Private$\MyQueue");
            }

            Message message = new Message();
            message.Formatter = new BinaryMessageFormatter();
            message.Body = url;
            msmqQueue.Label = "url link";
            msmqQueue.Send(message);
        }
    }
}
