// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILableRepository.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// ---------------------------------------------------------------------------------------------------------

namespace FundooRepository.Interfaces
{
    using FundooModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// ILableRepository interface 
    /// </summary>
    public interface ILableRepository
    {
        /// <summary>
        /// Adds the lable.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>string message</returns>
        public string AddLable(LableModel model);

        /// <summary>
        /// Retrieves the notes.
        /// </summary>
        /// <returns>string message</returns>
        public IEnumerable<LableModel> RetrieveLables();

        /// <summary>
        /// Removes the lable.
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>string message</returns>
        public string RemoveLable(int lableId);

        /// <summary>
        /// Updates the lables.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>string message</returns>
        public string UpdateLables(LableModel model);

        /// <summary>
        /// Retrieves the lable by identifier.
        /// </summary>
        /// <param name="id">lable id.</param>
        /// <returns>string message</returns>
        public LableModel RetrieveLableById(int lableId);
    }
}
