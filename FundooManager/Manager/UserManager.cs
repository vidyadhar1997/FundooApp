// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooManager.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooManager.Interface;
    using FundooModel.Models;
    using FundooRepository.Interfaces;

    /// <summary>
    /// UserManager class implementing interface IUserManager
    /// </summary>
    /// <seealso cref="FundooManager.Interface.IUserManager" />
    public class UserManager : IUserManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IUserRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public UserManager(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// result containing SUCCESS message
        /// </returns>
        public string Register(RegisterModel model)
        {
            string result = this.repository.Register(model);
            return result;
        }

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>LOGIN SUCCESS message</returns>
        public string Login(string email, string password)
        {
            string result = this.repository.Login(email, password);
            return result;
        }

        public string SendEmail(string emailAddress)
        {
            string result=this.repository.SendEmail(emailAddress);
            return result;
        }
    }
}
