// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooManager.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooModel.Models;

    /// <summary>
    /// IUserManager interface
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>result containing SUCCESS message</returns>
        public string Register(RegisterModel model);
    }
}
