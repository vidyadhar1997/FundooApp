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
    ///  ICollaboratorRepository interface
    /// </summary>
    public interface ICollaboratorRepository
    {
        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>string message</returns>
        public string AddCollaborator(CollaboratorModel model);

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="id">collaborator id</param>
        /// <returns>string message</returns>
        public string DeleteCollaborator(int id);

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <returns>string message</returns>
        public IEnumerable<CollaboratorModel> GetCollaborator();
    }
}
