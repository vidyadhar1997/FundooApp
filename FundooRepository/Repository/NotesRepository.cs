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
            this.userContext.NoteModel.Add(model);
            this.userContext.SaveChanges();
            return "ADD NOTES SUCCESSFULL";
        }

        /// <summary>
        /// Retrieves the notes.
        /// </summary>
        /// <returns>all notes</returns>
        public IEnumerable<NotesModel> RetrieveNotes()
        {
            IEnumerable<NotesModel> result;
            IEnumerable<NotesModel> notes = this.userContext.NoteModel;
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

        /// <summary>
        /// Removes the note.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>string message</returns>
        public string RemoveNote(int Id)
        {
            try
            {
                var notes = this.userContext.NoteModel.Find(Id);
                this.userContext.NoteModel.Remove(notes);
                this.userContext.SaveChangesAsync();
                return "NOTES DELETED SUCCESSFULL";
            }
            catch (NullReferenceException e)
            {
                throw e;
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
                }

                    this.userContext.SaveChanges();
                    return "UPDATE SUCCESSFULL";
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }
    }
}
