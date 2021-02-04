

namespace FundooManager.Interface
{
    using FundooModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICollaboratorManager
    {
        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Success message</returns>
        public string AddCollaborator(CollaboratorModel model);

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="id">collaborator id</param>
        /// <returns>Success message</returns>
        public string DeleteCollaborator(int collaboratorId);

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <returns>Success message</returns>
        public IEnumerable<CollaboratorModel> GetCollaborator();
    }
}
