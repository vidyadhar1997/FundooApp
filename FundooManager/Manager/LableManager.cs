﻿// --------------------------------------------------------------------------------------------------------------------
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
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool AddLable(LableModel model)
        {
            try
            {
                bool result = this.repository.AddLable(model);
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
        /// <returns>all lables</returns>
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

        /// <summary>
        /// Retrieves the lable by identifier.
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>
        /// particular lable
        /// </returns>
        /// <exception cref="Exception"></exception>
        public LableModel RetrieveLableById(int lableId)
        {
            try
            {
                LableModel lables=this.repository.RetrieveLableById(lableId);
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
        /// <param name="id">lable id</param>
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool RemoveLable(int lableId)
        {
            try
            {
                bool result = this.repository.RemoveLable(lableId);
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
        /// <returns>string message</returns>
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
