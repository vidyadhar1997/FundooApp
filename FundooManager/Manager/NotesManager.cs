// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesManager.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooManager.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooManager.Interface;
    using FundooModel.Models;
    using FundooRepository.Interfaces;

    /// <summary>
    /// NotesManager class
    /// </summary>
    /// <seealso cref="FundooManager.Interface.INotesManager" />
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
        /// <returns>string message</returns>
        public string AddNotes(NotesModel model)
        {
            try
            {
                string result = this.repository.AddNotes(model);
                return result;
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
                IEnumerable<NotesModel> notes = this.repository.RetrieveNotes();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the notes by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public NotesModel RetrieveNotesById(int id)
        {
            try
            {
                NotesModel notes = this.repository.RetrieveNotesById(id);
                return notes;
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
                string result = this.repository.RemoveNote(Id);
                return result;
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
                string result = this.repository.UpdateNotes(model);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Pins the or unpin.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string PinOrUnpin(int id)
        {
            try
            {
                string result = this.repository.PinOrUnpin(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Archives the or un archive.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string ArchiveOrUnArchive(int id)
        {
            try
            {
                string result = this.repository.ArchiveOrUnarchive(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Determines whether the specified identifier is trash.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string isTrash(int id)
        {
            try
            {
                string result = this.repository.IsTrash(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds the reminder.
        /// </summary>
        /// <param name="id">note id.</param>
        /// <param name="reminder">The reminder.</param>
        /// <returns>string message</returns>
        /// <exception cref="Exception"></exception>
        public string AddReminder(int id, string reminder)
        {
            try
            {
                string result= this.repository.AddReminder(id,reminder);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets all notes whoes reminder is set.
        /// </summary>
        /// <returns>notes whose reminder is set</returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<NotesModel> GetAllNotesWhoesReminderIsSet()
        {
            try
            {
                IEnumerable<NotesModel> notes = this.repository.RetrieveNotes();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
