using FundooModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interface
{
    public interface ICollaboratorManager
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
    }
}
