// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesRepository.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooModel.Models;

    /// <summary>
    /// INotesRepository interface
    /// </summary>
    public interface INotesRepository
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

        /// <summary>
        /// Archives the or unarchive.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public string ArchiveOrUnarchive(int id);

        /// <summary>
        /// Determines whether the specified identifier is trash.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public string IsTrash(int id);

        /// <summary>
        /// Adds the reminder.
        /// </summary>
        /// <param name="id">note id.</param>
        /// <param name="reminder">The reminder.</param>
        /// <returns>string message</returns>
        public string AddReminder(int id, string reminder);

        /// <summary>
        /// Gets all notes whoes reminder is set.
        /// </summary>
        /// <returns>all notes whos reminder is set</returns>
        public IEnumerable<NotesModel> GetAllNotesWhoesReminderIsSet();
    }
}
