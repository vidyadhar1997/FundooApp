using FundooModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interface
{
    /// <summary>
    /// INotesManager interface
    /// </summary>
    public interface INotesManager
    {
        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public string AddNotes(NotesModel model);
    }
}
