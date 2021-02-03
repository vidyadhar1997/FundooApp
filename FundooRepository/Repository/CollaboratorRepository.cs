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

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string DeleteCollaborator(int id)
        {
            try
            {
                if (id > 0)
                {
                    var collaborator = this.userContext.Collaborator.Find(id);
                    this.userContext.Collaborator.Remove(collaborator);
                    this.userContext.SaveChangesAsync();
                    return "COLLABORATOR DELETED SUCCESSFULL";
                }
                return "Unable to delete collaborator:id is not correct";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<CollaboratorModel> GetCollaborator()
        {
            try
            {
                IEnumerable<CollaboratorModel> result;
                IEnumerable<CollaboratorModel> notes = this.userContext.Collaborator;
                if (notes != null)
                {
                    result = notes;
                }
                else
                {
                    result = null;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
