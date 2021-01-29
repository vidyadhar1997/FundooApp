// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepository.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooModel.Models;
    using FundooRepository.Context;
    using FundooRepository.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// NotesRepository class
    /// </summary>
    /// <seealso cref="FundooRepository.Interfaces.INotesRepository" />
    public class NotesRepository : INotesRepository
    {
        /// <summary>
        /// The user context
        /// </summary>
        private UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public NotesRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>return message</returns>
        public string AddNotes(NotesModel model)
        {
            try
            {
                this.userContext.Note_Model.Add(model);
                this.userContext.SaveChanges();
                return "ADD NOTES SUCCESSFULL";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the notes.
        /// </summary>
        /// <returns>all notes</returns>
        public IEnumerable<NotesModel> RetrieveNotes()
        {
            try
            {
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> notes = this.userContext.Note_Model;
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
        /// Removes the note.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>string message</returns>
        public string RemoveNote(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var notes = this.userContext.Note_Model.Find(Id);
                    this.userContext.Note_Model.Remove(notes);
                    this.userContext.SaveChangesAsync();
                    return "NOTES DELETED SUCCESSFULL";
                }
                return "Unable to delete notes:id is not correct";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>string message</returns>
        public string UpdateNotes(NotesModel model)
        {
            try
            {
                if (model.NoteId != 0)
                {
                    this.userContext.Entry(model).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    return "UPDATE SUCCESSFULL";
                }
                return "Updation Failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
