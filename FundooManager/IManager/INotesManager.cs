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
    using Microsoft.AspNetCore.Http;

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
        public bool AddNotes(NotesModel model);

        /// <summary>
        /// Retrieves the notes.
        /// </summary>
        /// <returns>all notes</returns>
        public IEnumerable<NotesModel> RetrieveNotes();

        /// <summary>
        /// Retrieves the notes by identifier.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>String message</returns>
        public NotesModel RetrieveNotesById(int noteId);

        /// <summary>
        /// Removes the note.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>string message</returns>
        public bool RemoveNote(int noteId);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>string message</returns>
        public string UpdateNotes(NotesModel model);

        /// <summary>
        /// Pins the or unpin.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>String message</returns>
        public string PinOrUnpin(int noteId);

        /// <summary>
        /// Archives the or un archive.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>String message</returns>
        public string ArchieveOrUnArchieve(int noteId);

        /// <summary>
        /// Retrieves the archive notes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NotesModel> RetrieveArchieveNotes();

        /// <summary>
        /// Determines whether the specified identifier is trash.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>String message</returns>
        public string isTrash(int noteId);

        /// <summary>
        /// Retrieves the trash notes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NotesModel> RetrieveTrashNotes();

        /// <summary>
        /// Adds the reminder.
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="reminder">The reminder.</param>
        /// <returns>string message</returns>
        public bool AddReminder(int noteId, string reminder);

        /// <summary>
        /// Gets all notes whoes reminder is set.
        /// </summary>
        /// <returns>all notes whose reminder is set</returns>
        public IEnumerable<NotesModel> GetAllNotesWhoesReminderIsSet();

        /// <summary>
        /// Unsets the reminder.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public bool UnsetReminder(int noteId);

        /// <summary>
        /// Add the color.
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="color">The color.</param>
        /// <returns>string message</returns>
        public bool AddColor(int noteId, string color);

        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <param name="noteimage">The noteimage.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool UploadImage(int noteId, IFormFile noteimage);
    }
}
