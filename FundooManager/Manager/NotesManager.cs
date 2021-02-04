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
    using Microsoft.AspNetCore.Http;

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
        /// <returns>return true or false</returns>
        public bool AddNotes(NotesModel model)
        {
            try
            {
                bool result = this.repository.AddNotes(model);
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
        /// <param name="id">note id</param>
        /// <returns>particular note</returns>
        /// <exception cref="Exception"></exception>
        public NotesModel RetrieveNotesById(int noteId)
        {
            try
            {
                NotesModel notes = this.repository.RetrieveNotesById(noteId);
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
        /// <param name="Id">note id</param>
        /// <returns>return true or false</returns>
        public bool RemoveNote(int noteId)
        {
            try
            {
                bool result = this.repository.RemoveNote(noteId);
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
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        /// <exception cref="Exception"></exception>
        public string PinOrUnpin(int noteId)
        {
            try
            {
                string result = this.repository.PinOrUnpin(noteId);
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
        /// <param name="id">note id</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string ArchieveOrUnArchieve(int noteId)
        {
            try
            {
                string result = this.repository.ArchieveOrUnarchieve(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the archive notes.
        /// </summary>
        /// <returns>all archieve notes</returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<NotesModel> RetrieveArchieveNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.repository.RetrieveArchieveNotes();
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Determines whether the specified identifier is trash.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        /// <exception cref="Exception"></exception>
        public string isTrash(int noteId)
        {
            try
            {
                string result = this.repository.IsTrash(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Empties the trash.
        /// </summary>
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool EmptyTrash()
        {
            try
            {
                bool result = this.repository.EmptyTrash();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the trash notes.
        /// </summary>
        /// <returns>all trash notes</returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<NotesModel> RetrieveTrashNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.repository.RetrieveTrashNotes();
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
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool AddReminder(int noteId, string reminder)
        {
            try
            {
                bool result = this.repository.AddReminder(noteId, reminder);
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
                IEnumerable<NotesModel> notes = this.repository.GetAllNotesWhoesReminderIsSet();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Unsets the reminder.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool UnsetReminder(int noteId)
        {
            try
            {
                bool result = this.repository.UnSetReminder(noteId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds the color.
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="color">The color.</param>
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool AddColor(int noteId, string color)
        {
            try
            {
                bool result = this.repository.AddColour(noteId, color);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <param name="Noteimage">The noteimage.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>return true or false</returns>
        /// <exception cref="Exception"></exception>
        public bool UploadImage(int noteId, IFormFile noteimage)
        {
            try
            {
                bool result = this.repository.UploadImage(noteId, noteimage);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
