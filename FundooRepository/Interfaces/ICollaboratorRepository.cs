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
        /// <returns></returns>
        public string AddCollaborator(CollaboratorModel model);

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public string DeleteCollaborator(int id);

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CollaboratorModel> GetCollaborator();
    }
}
