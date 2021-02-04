﻿// --------------------------------------------------------------------------------------------------------------------
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
    using Microsoft.AspNetCore.Http;

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
        public bool AddNotes(NotesModel model);

        /// <summary>
        /// Retrieves the notes.
        /// </summary>
        /// <returns>all notes</returns>
        public IEnumerable<NotesModel> RetrieveNotes();

        /// <summary>
        /// Retrieves the notes by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>note model</returns>
        public NotesModel RetrieveNotesById(int id);

        /// <summary>
        /// Removes the note.
        /// </summary>
        /// <param name="Id">note id</param>
        /// <returns>string message</returns>
        public bool RemoveNote(int Id);

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
        /// <returns></returns>
        public string PinOrUnpin(int id);

        /// <summary>
        /// Archives the or unarchive.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>string message</returns>
        public string ArchieveOrUnarchieve(int id);

        /// <summary>
        /// Retrieves the archive notes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NotesModel> RetrieveArchieveNotes();

        /// <summary>
        /// Determines whether the specified identifier is trash.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string IsTrash(int id);

        /// <summary>
        /// Retrieves the trash notes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NotesModel> RetrieveTrashNotes();

        /// <summary>
        /// Empties the trash.
        /// </summary>
        /// <returns></returns>
        public bool EmptyTrash();

        /// <summary>
        /// Adds the reminder.
        /// </summary>
        /// <param name="id">note id.</param>
        /// <param name="reminder">The reminder.</param>
        /// <returns>string message</returns>
        public bool AddReminder(int id, string reminder);

        /// <summary>
        /// Gets all notes whoes reminder is set.
        /// </summary>
        /// <returns>all notes whos reminder is set</returns>
        public IEnumerable<NotesModel> GetAllNotesWhoesReminderIsSet();

        /// <summary>
        /// Unset the reminder.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public bool UnSetReminder(int id);

        /// <summary>
        /// Adds the colour.
        /// </summary>
        /// <param name="id">note id.</param>
        /// <param name="color">The color.</param>
        /// <returns>string message</returns>
        public bool AddColour(int id, string color);

        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <param name="Noteimage">The noteimage.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool UploadImage(int id, IFormFile noteimage);
    }
}
