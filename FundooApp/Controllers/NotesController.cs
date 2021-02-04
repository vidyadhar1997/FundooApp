﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModel.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// NotesController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// The notes manager
        /// </summary>
        private readonly INotesManager notesManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="notesManager">The notes manager.</param>
        public NotesController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>response data</returns>
        [HttpPost]
        public ActionResult AddNotes([FromBody] NotesModel model)
        {
            try
            {
                bool result = this.notesManager.AddNotes(model);

                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = "Notes Added Successfully", Data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Add Notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// RetrieveNotes to retrieve all the notes
        /// </summary>
        /// <returns>response data</returns>
        [HttpGet]
        public IActionResult RetrieveNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.RetrieveNotes();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Retrieve Notes Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// RetrieveNotesById to retrieve particular notes
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>response data</returns>
        [HttpGet]
        [Route("{noteId}")]
        public IActionResult RetrieveNotesById(int noteId)
        {
            try
            {
                NotesModel result = this.notesManager.RetrieveNotesById(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = "Retrieve Notes By Id Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes By id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// DeleteNotes for delete specific notes
        /// </summary>
        /// <param name="id">notes id</param>
        /// <returns>response data</returns>
        [HttpDelete]
        [Route("{noteId}")]
        public IActionResult DeleteNotes(int noteId)
        {
            try
            {
                var result = this.notesManager.RemoveNote(noteId);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Delete Note Successfully", Data = noteId });
                }

                return this.BadRequest(new { Status = false, Message = "Unable to delete note : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// UpdateNotes for updating notes
        /// </summary>
        /// <param name="model">notes model</param>
        /// <returns>response data</returns>
        [HttpPut]
        public IActionResult UpdateNotes([FromBody] NotesModel model)
        {
            try
            {
                var result = this.notesManager.UpdateNotes(model);
                if (result.Equals("UPDATE SUCCESSFULL"))
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = result, Data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Error while updating notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves the notes by pin.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("pinOrUnpin")]
        public IActionResult PinOrUnpinNote(int noteId)
        {
            try
            {
                var result = this.notesManager.PinOrUnpin(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Archives the or unarchive.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("archieveOrUnarchieve")]
        public IActionResult ArchieveOrUnarchieve(int noteId)
        {
            try
            {
                var result = this.notesManager.ArchieveOrUnArchieve(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Retrieve All Archive Notes 
        /// </summary>
        /// <returns>response body</returns>
        [HttpGet]
        [Route("retrieveAllArchieveNotes")]
        public IActionResult RetrieveAllArchieveNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.RetrieveArchieveNotes();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Retrieve Notes Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Trashes the or untrash.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("trashOrUntrash")]
        public IActionResult TrashOrUntrash(int noteId)
        {
            try
            {
                var result = this.notesManager.isTrash(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// RetrieveAllTrashNotes method
        /// </summary>
        /// <returns>response data</returns>
        [HttpGet]
        [Route("retrieveAllTrashNotes")]
        public IActionResult RetrieveAllTrashNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.RetrieveTrashNotes();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Retrieve Notes Successfully", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Sets the reminder.
        /// </summary>
        /// <param name="id">note id.</param>
        /// <param name="reminder">The reminder.</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("setReminder")]
        public IActionResult SetReminder(int noteId, string reminder)
        {
            try
            {
                var result = this.notesManager.AddReminder(noteId, reminder);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Reminder Set Successfully", Data = reminder });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets all notes whose reminder is set.
        /// </summary>
        /// <returns>Response data</returns>
        [HttpGet]
        [Route("getAllNotesWhoseReminderIsSet")]
        public IActionResult GetAllNotesWhoseReminderIsSet()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetAllNotesWhoesReminderIsSet();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Retrieve All Notes Whose Reminder Is Set", Data = result });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Notes" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Uns the set reminder.
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("unSetReminder")]
        public IActionResult UnSetReminder(int noteId)
        {
            try
            {
                var result = this.notesManager.UnsetReminder(noteId);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Unset Reminder For Note Sucessfully", Data = noteId });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Adds the color.
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="color">The color</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("addColor")]
        public IActionResult AddColor(int noteId, string color)
        {
            try
            {
                var result = this.notesManager.AddColor(noteId, color);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Add Colour Sucessfully", Data = color });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Insert Image
        /// </summary>
        /// <param name="image">image parameter</param>
        /// <param name="id">note id</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("uploadImage")]
        public IActionResult UploadImage(int noteId, IFormFile image)
        {
            try
            { 
                var result = this.notesManager.UploadImage(noteId, image);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Upload Image Successfully", Data = noteId });
                }

                return this.BadRequest(new { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}