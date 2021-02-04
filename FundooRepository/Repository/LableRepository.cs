// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LableRepository.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Repository
{
    using FundooModel.Models;
    using FundooRepository.Context;
    using FundooRepository.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// LableRepository class
    /// </summary>
    /// <seealso cref="FundooRepository.Interfaces.ILableRepository" />
    public class LableRepository : ILableRepository
    {
        /// <summary>
        /// The user context
        /// </summary>
        private UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public LableRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool AddLable(LableModel model)
        {
            try
            {
                this.userContext.Lable_Models.Add(model);
                this.userContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the notes.
        /// </summary>
        /// <returns>all lables</returns>
        /// <exception cref="Exception">ex.message</exception>
        public IEnumerable<LableModel> RetrieveLables()
        {
            try
            {
                IEnumerable<LableModel> result;
                IEnumerable<LableModel> notes = this.userContext.Lable_Models;
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

        /// <summary>
        /// Retrieves the lable by identifier.
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>lable model</returns>
        /// <exception cref="Exception">ex.Message</exception>
        public LableModel RetrieveLableById(int lableId)
        {
            try
            {
                LableModel notes = this.userContext.Lable_Models.Where(x => x.LableId == lableId).SingleOrDefault();
                return notes;
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
        /// <exception cref="Exception">ex.message</exception>
        public bool RemoveLable(int lableId)
        {
            try
            {
                if (lableId > 0)
                {
                    var lables = this.userContext.Lable_Models.Find(lableId);
                    this.userContext.Lable_Models.Remove(lables);
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
        /// Updates the lables.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>string message</returns>
        /// <exception cref="Exception">ex.message</exception>
        public string UpdateLables(LableModel model)
        {
            try
            {
                if (model.LableId != 0)
                {
                    this.userContext.Entry(model).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    return "UPDATE LABLE SUCCESSFULL";
                }
                return "Updation For Lable Failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
