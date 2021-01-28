// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;
    using Experimental.System.Messaging;
    using FundooModel.Models;
    using FundooRepository.Context;
    using FundooRepository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using StackExchange.Redis;

    /// <summary>
    /// User Repository
    /// </summary>
    /// <seealso cref="FundooRepository.Interfaces.IUserRepository" />
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The signing key/
        /// </summary>
        public static readonly SymmetricSecurityKey SIGNINGKEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(UserRepository.SECRETKEY));

        /// <summary>
        /// The secret key
        /// </summary>
        private const string SECRETKEY = "this is my custom Secret key for authnetication";

        /// <summary>
        /// The user context
        /// </summary>
        private UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>success message</returns>
        public string Register(RegisterModel model)
        {
            this.userContext.RegisterModels.Add(model);
            this.userContext.SaveChanges();
            return "REGISTERATION SUCCESSFULL";
        }

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>LOGIN SUCCESS message</returns>
        public string Login(string email, string password)
        {
            string message;
            var login = this.userContext.RegisterModels.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
            if (login != null)
            {
                message = "LOGIN SUCCESS";
                ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                IDatabase database = connectionMultiplexer.GetDatabase();
                database.StringSet(key: "Email",email);
                var redisValue=database.StringGet("Email");
            }
            else
            {
                message = "LOGIN UNSUCCESSFUL";
            }

            return message;
        }

        /// <summary>
        /// SendEmail Method for the sending email
        /// </summary>
        /// <param name="emailAddress">email Address</param>
        /// <returns>success message</returns>
        public string SendEmail(string emailAddress)
        {
            var url = "https://www.codeproject.com/Articles/165576/Use-of-MSMQ-for-Sending-Bulk-Mails";
            MessageQueue msmqQueue = new MessageQueue();
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

            //reading message from msmq
            var reciever = new MessageQueue(@".\Private$\MyQueue");
            var recieving = reciever.Receive();
            recieving.Formatter = new BinaryMessageFormatter();
            string linkToBeSend = recieving.Body.ToString();

            string body;
            string subject = "FundooApp Credential";
            var entry = this.userContext.RegisterModels.FirstOrDefault(x => x.Email == emailAddress);
            if (entry != null)
            {
                body = linkToBeSend;
            }
            else
            {
                return "Not Found";
            }

            using (MailMessage mailMessage = new MailMessage("vidyadharhudge1997@gmail.com", emailAddress))
            {
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("vidyadharhudge1997@gmail.com", "Dhiraj@123#");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
                return "SUCCESS";
            }
        }

        /// <summary>
        /// ResetPassword method
        /// </summary>
        /// <param name="resetPassword">reset Password</param>
        /// <returns>success message</returns>
        public string ResetPassword(ResetPassword resetPassword)
        {
            var Entries = this.userContext.RegisterModels.FirstOrDefault(x => x.Email == resetPassword.Email);
            if (Entries != null)
            {
                if (resetPassword.Password == resetPassword.ConfirmPassword)
                {
                    Entries.Password = resetPassword.Password;
                    this.userContext.Entry(Entries).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    return "RESET PASSWORD SUCCESSFULL";
                }
                else
                {
                    return "Password And Confirm Password Not Matched";
                }
            }
            else
            {
                return "NOT FOUND";
            }
        }

        /// <summary>
        /// GenerateToken method
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns>token for specific email</returns>
        public string GenerateToken(string userEmail)
        {
            var token = new JwtSecurityToken(
            claims: new Claim[]
            {
                new Claim(ClaimTypes.Name, userEmail)
            },
            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
            expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
            signingCredentials: new SigningCredentials(SIGNINGKEY, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
