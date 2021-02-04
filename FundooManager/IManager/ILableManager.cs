// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILableManager.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooManager.Interface
{
    using FundooModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///  ILableManager interface
    /// </summary>
    public interface ILableManager
    {
        /// <summary>
        /// Adds the lable.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>String message</returns>
        public string AddLable(LableModel model);

        /// <summary>
        /// Retrieves the lables.
        /// </summary>
        /// <returns>String message</returns>
        public IEnumerable<LableModel> RetrieveLables();

        /// <summary>
        /// Removes the lable.
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>String message</returns>
        public string RemoveLable(int id);

        /// <summary>
        /// Updates the lables.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>String message</returns>
        public string UpdateLables(LableModel model);

        /// <summary>
        /// Retrieves the lable by identifier.
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>String message</returns>
        public LableModel RetrieveLableById(int id);
    }
}
