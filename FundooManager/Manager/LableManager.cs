// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesManager.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// -----------------------------------------------------------------------------------------------------------

namespace FundooManager.Manager
{
    using FundooManager.Interface;
    using FundooModel.Models;
    using FundooRepository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// LableManager class
    /// </summary>
    /// <seealso cref="FundooManager.Interface.ILableManager" />
    public class LableManager : ILableManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ILableRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableManager"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public LableManager(ILableRepository userRepository)
        {
            this.repository = userRepository;
        }

        /// <summary>
        /// Adds the lable.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string AddLable(LableModel model)
        {
            try
            {
                string result = this.repository.AddLable(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the lables.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<LableModel> RetrieveLables()
        {
            try
            {
                IEnumerable<LableModel> lables = this.repository.RetrieveLables();
                return lables;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public LableModel RetrieveLableById(int id)
        {
            try
            {
                LableModel lables=this.repository.RetrieveLableById(id);
                if (lables != null)
                {
                    return lables;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the lable.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string RemoveLable(int id)
        {
            try
            {
                string result = this.repository.RemoveLable(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the lables.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string UpdateLables(LableModel model)
        {
            try
            {
                string result = this.repository.UpdateLables(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
