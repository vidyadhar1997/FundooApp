using FundooManager.Interface;
using FundooModel.Models;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class NotesManager : INotesManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly INotesRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesManager"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        public NotesManager(INotesRepository userRepository)
        {
            this.repository = userRepository;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public string AddNotes(NotesModel model)
        {
            string result = this.repository.AddNotes(model);
            return result;
        }
        public IEnumerable<NotesModel> RetrieveNotes()
        {
            IEnumerable<NotesModel> notes = this.repository.RetrieveNotes();
            return notes;
        }
    }
}
