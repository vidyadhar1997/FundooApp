﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepository.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using FundooModel.Models;
    using FundooRepository.Context;
    using FundooRepository.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// NotesRepository class
    /// </summary>
    /// <seealso cref="FundooRepository.Interfaces.INotesRepository" />
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
            try
            {
                this.userContext.Note_model.Add(model);
                this.userContext.SaveChanges();
                return "ADD NOTES SUCCESSFULL";
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
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> notes = this.userContext.Note_model;
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the notes by identifier.
        /// </summary>
        /// <param name="id">note id.</param>
        /// <returns>string message</returns>
        /// <exception cref="Exception"></exception>
        public NotesModel RetrieveNotesById(int noteId)
        {
            try
            {
                NotesModel notes = this.userContext.Note_model.Find(noteId);
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
        /// <returns>string message</returns>
        public string RemoveNote(int noteId)
        {
            try
            {
                if (noteId > 0)
                {
                    var notes = this.userContext.Note_model.Find(noteId);
                    if (notes != null)
                    {
                        if (notes.isTrash == true)
                        {
                            this.userContext.Note_model.Remove(notes);
                            this.userContext.SaveChangesAsync();
                            return "NOTES DELETED SUCCESSFULL";
                        }
                    }
                }
                return "First trash note then delete it";
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
                if (model.NoteId != 0)
                {
                    this.userContext.Entry(model).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    return "UPDATE SUCCESSFULL";
                }
                return "Updation Failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// PinOrUnpin the notes
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string  PinOrUnpin(int noteId)
        {
            try
            {
                var notes=this.userContext.Note_model.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes.Pin == false)
                {
                    notes.Pin = true;
                    userContext.Entry(notes).State=EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note is getting pin";
                    return message;
                }
                if (notes.Pin == true)
                {
                    notes.Pin = false;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note Unpinned";
                    return message;
                }
                return "Unable to Pin or Unpin notes";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Archives the or unarchive.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        /// <exception cref="Exception"></exception>
        public string ArchieveOrUnarchieve(int noteId)
        {
            try
            {
                var notes = this.userContext.Note_model.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes.Archive == false)
                {
                    notes.Archive = true;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note is Archieve";
                    return message;
                }
                if (notes.Archive == true)
                {
                    notes.Archive = false;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note UnArchieve";
                    return message;
                }
                return "Unable to Archieve or UnArchieve notes";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the archive notes.
        /// </summary>
        /// <returns>all notes i archive</returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<NotesModel> RetrieveArchieveNotes()
        {
            try
            {
                IEnumerable<NotesModel>notes= this.userContext.Note_model.Where(x => x.Archive == true).ToList();
                return notes;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// IsTrash 
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string IsTrash(int noteId)
        {
            try
            {
                var notes = this.userContext.Note_model.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (notes.isTrash == false)
                {
                    notes.isTrash = true;
                    userContext.Entry(notes).State=EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Notes Is Trashed";
                    return message;
                }
                if (notes.isTrash == true)
                {
                    notes.isTrash = false;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Note Restored";
                    return message;
                }

                return "Unable to Trash or Restored notes";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the trash notes.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<NotesModel> RetrieveTrashNotes()
        {
            try
            {
                IEnumerable<NotesModel> notes = this.userContext.Note_model.Where(x => x.isTrash == true).ToList();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds the reminder.
        /// </summary>
        /// <param name="id">Note Id</param>
        /// <param name="reminder">The reminder.</param>
        /// <returns>string message</returns>
        /// <exception cref="Exception"></exception>
        public string AddReminder(int noteId, string reminder)
        {
            try
            {
               var notes= this.userContext.Note_model.Find(noteId);
                if (notes != null)
                {
                    notes.Reminder = reminder;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Reminder Is Set For This Note Successfully";
                    return message;
                }
                return "Error While Setting The Reminder";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the reminder by identifier.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>notes</returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<NotesModel> GetAllNotesWhoesReminderIsSet()
        {
            try
            {
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> notes = this.userContext.Note_model.Where(x=>x.Reminder.Length>0);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Uns the set reminder.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        /// <exception cref="Exception"></exception>
        public string UnSetReminder(int noteId)
        {
            try
            {
                var notes=this.userContext.Note_model.Find(noteId);
                if (notes != null)
                {
                    notes.Reminder = null;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Reminder Is UnSet For This Note Successfully";
                    return message;
                }
                return "Error While UnSet The Reminder";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds the colour.
        /// </summary>
        /// <param name="id">note id.</param>
        /// <param name="color">The color.</param>
        /// <returns>string message</returns>
        /// <exception cref="Exception"></exception>
        public string AddColour(int noteId, string color)
        {
            try
            {
                var notes = this.userContext.Note_model.Find(noteId);
                if (notes != null)
                {
                    notes.Colour = color;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Color Is Set For This Note Successfully";
                    return message;
                }
                return "Error While Setting The Color";
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
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Obsolete]
        public string UploadImage(int noteId, IFormFile noteimage)
        {
            try
            {
                var notes = this.userContext.Note_model.Find(noteId);
                if (notes != null)
                {
                    Account account = new Account("ddtfdhioq", "584249449888143", "dUjpgfFHSgcgrDwK4FOBUZzrnPk");
                    var path = noteimage.OpenReadStream();
                    Cloudinary cloudinary = new Cloudinary(account);
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(noteimage.FileName, path)
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    notes.Image=uploadResult.Uri.AbsolutePath;
                    userContext.Entry(notes).State = EntityState.Modified;
                    userContext.SaveChanges();
                    string message = "Image Inserted For This Note Successfully";
                    return message;
                }
                return "Error While Inserting The Image";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
