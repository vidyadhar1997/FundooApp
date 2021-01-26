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
    using System.Linq;
    using System.Text;
    using FundooModel.Models;
    using FundooRepository.Context;
    using FundooRepository.Interfaces;

    /// <summary>
    /// User Repository
    /// </summary>
    /// <seealso cref="FundooRepository.Interfaces.IUserRepository" />
    public class UserRepository : IUserRepository
    {
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
            return "SUCCESS";
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
            }
            else
            {
                message = "LOGIN UNSUCCESSFUL";
            }

            return message;
        }
    }
}
