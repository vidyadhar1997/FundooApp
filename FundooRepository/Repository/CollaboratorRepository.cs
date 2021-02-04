﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Repository
{
    using FundooModel.Models;
    using FundooRepository.Context;
    using FundooRepository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// CollaboratorRepository class
    /// </summary>
    /// <seealso cref="FundooRepository.Interfaces.ICollaboratorRepository" />
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
        /// <returns>string message</returns>
        /// <exception cref="Exception"></exception>
        public bool AddCollaborator(CollaboratorModel model)
        {
            try
            {
                this.userContext.Collaborator.Add(model);
                this.userContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="id">collaborator id</param>
        /// <returns>string message</returns>
        /// <exception cref="Exception"></exception>
        public bool DeleteCollaborator(int collaboratorId)
        {
            try
            {
                if (collaboratorId > 0)
                {
                    var collaborator = this.userContext.Collaborator.Find(collaboratorId);
                    this.userContext.Collaborator.Remove(collaborator);
                    this.userContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <returns>all collaborator</returns>
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
