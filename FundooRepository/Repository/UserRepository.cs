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
    using MSMQ;
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
        private const string SECRETKEY = "SuperSecretKey@345fghhhhhhhhhhhhhhhhhhhhhhhhhhhhhfggggggg";

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
            try
            {
                model.Password = EncryptPassword(model.Password);
                this.userContext.Register_Models.Add(model);
                this.userContext.SaveChanges();
                return "REGISTERATION SUCCESSFULL";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// EncryptPassword methode to encrypt password
        /// </summary>
        /// <param name="password"></param>
        /// <returns>encoded data</returns>
        public static string EncryptPassword(string password)
        {
            try
            {
                byte[] encryptData = new byte[password.Length];
                encryptData = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encryptData);
                return encodedData;
            } 
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>LOGIN SUCCESS message</returns>
        public string Login(string email, string password)
        {
            try
            {
                string message;
                password = EncryptPassword(password);
                var login = this.userContext.Register_Models.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
                if (login != null)
                {
                    message = "LOGIN SUCCESS";
                    //Redis cache implemetation
                   /* ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(key: "Email", email);
                    var redisValue = database.StringGet("Email");*/
                }
                else
                {
                    message = "LOGIN UNSUCCESSFUL";
                }
                return message;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// SendEmail Method for the sending email
        /// </summary>
        /// <param name="emailAddress">email Address</param>
        /// <returns>success message</returns>
        public string SendEmail(string emailAddress)
        {
            try
            {
                string body;
                string subject = "Link To Reset Your FundooApp Credential";
                var entry = this.userContext.Register_Models.FirstOrDefault(x => x.Email == emailAddress);
                if (entry != null)
                {
                    Sender sender = new Sender();
                    sender.Send();
                    Reciver reciver = new Reciver();
                    var message = reciver.Recive();
                    body = message;
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
                    }

                    return "MAIL SENT SUCCESSFULLY";
                }
                else
                {
                    return "Error while sending mail ";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        /// <summary>
        /// ResetPassword method
        /// </summary>
        /// <param name="resetPassword">reset Password</param>
        /// <returns>success message</returns>
        public string ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                var Entries = this.userContext.Register_Models.FirstOrDefault(x => x.Email == resetPassword.Email);
                if (Entries != null)
                {
                    if (resetPassword.Password == resetPassword.ConfirmPassword)
                    {
                        Entries.Password = EncryptPassword(resetPassword.Password);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GenerateToken method
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns>token for specific email</returns>
        public string GenerateToken(string userEmail)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
