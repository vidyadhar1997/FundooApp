﻿using FundooModel.Models;
using FundooRepository.Context;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Repository
{
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
            return "INSERT DATA SUCCESSFULL";
        }
        public IEnumerable<NotesModel> RetrieveNotes()
        {
            IEnumerable<NotesModel> result;
            IEnumerable< NotesModel> notes = this.userContext.NoteModel;
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
    }
}
