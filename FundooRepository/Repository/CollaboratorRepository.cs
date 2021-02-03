using FundooModel.Models;
using FundooRepository.Context;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Repository
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// The user context
        /// </summary>
        private UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string AddCollaborator(CollaboratorModel model)
        {
            try
            {
                this.userContext.Collaborator.Add(model);
                this.userContext.SaveChanges();
                return "NEW COLLABORATOR ADDED SUCCESSFULL";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
