// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesManager.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooManager.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooModel.Models;

    /// <summary>
    /// INotesManager interface
    /// </summary>
    public interface INotesManager
    {
        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>string message</returns>
        public string AddNotes(NotesModel model);

        /// <summary>
        /// Retrieves the notes.
        /// </summary>
        /// <returns>all notes</returns>
        public IEnumerable<NotesModel> RetrieveNotes();

        /// <summary>
        /// Retrieves the notes by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public NotesModel RetrieveNotesById(int id);

        /// <summary>
        /// Removes the note.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>string message</returns>
        public string RemoveNote(int Id);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>string message</returns>
        public string UpdateNotes(NotesModel model);

        /// <summary>
        /// Pins the or unpin.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public string PinOrUnpin(int id);
        public string ArchiveOrUnArchive(int id);
    }
}
