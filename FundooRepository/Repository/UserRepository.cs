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
    }
}
