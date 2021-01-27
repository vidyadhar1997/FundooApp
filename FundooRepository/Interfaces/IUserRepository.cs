// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooModel.Models;

    /// <summary>
    /// IUserRepository interface
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>SUCCESS message</returns>
        public string Register(RegisterModel model);

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>message is LOGIN SUCCESS</returns>
        public string Login(string email, string password);

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>string message</returns>
        public string SendEmail(string emailAddress);

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="resetPassword">The reset password.</param>
        /// <returns>string message</returns>
        public string ResetPassword(ResetPassword resetPassword);
    }
}