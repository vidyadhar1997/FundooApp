using FundooModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interfaces
{
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
