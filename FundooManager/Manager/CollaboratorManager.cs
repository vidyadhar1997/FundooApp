using FundooManager.Interface;
using FundooModel.Models;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class CollaboratorManager : ICollaboratorManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ICollaboratorRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorManager"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public CollaboratorManager(ICollaboratorRepository userRepository)
        {
            this.repository = userRepository;
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
                string result = this.repository.AddCollaborator(model);
                return result;
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
                string result = this.repository.DeleteCollaborator(id);
                return result;
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
                IEnumerable<CollaboratorModel> lables = this.repository.GetCollaborator();
                return lables;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
