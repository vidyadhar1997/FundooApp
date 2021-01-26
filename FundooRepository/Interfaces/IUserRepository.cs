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
    }
}
