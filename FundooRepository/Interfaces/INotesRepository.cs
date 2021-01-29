using FundooModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interfaces
{
    /// <summary>
    /// INotesRepository interface
    /// </summary>
    public interface INotesRepository
    {
        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public string AddNotes(NotesModel model);
        public IEnumerable<NotesModel> RetrieveNotes();
        public string RemoveNote(int Id);
        public string UpdateNotes(NotesModel model);
    }
}
