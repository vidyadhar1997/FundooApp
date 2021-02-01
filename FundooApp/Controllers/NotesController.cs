// --------------------------------------------------------------------------------------------------------------------
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
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// NotesController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
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
        /// <returns>success message</returns>
        [HttpPost]
        public ActionResult AddNotes([FromBody] NotesModel model)
        {
            try
            {
                string result = this.notesManager.AddNotes(model);
                if (result.Equals("ADD NOTES SUCCESSFULL"))
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = result, Data = model });

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
        /// <returns>success message</returns>
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
        /// <param name="id"></param>
        /// <returns>sucesses message</returns>
        [HttpGet]
        [Route("retrieveNotesById")]
        public IActionResult RetrieveNotesById(int id)
        {
            try
            {
                NotesModel result = this.notesManager.RetrieveNotesById(id);
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
        /// <returns>notes deleted message</returns>
        [HttpDelete]
        public IActionResult DeleteNotes(int id)
        {
            try
            {
                var result = this.notesManager.RemoveNote(id);
                if (result.Equals("NOTES DELETED SUCCESSFULL"))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = result, Data = id });
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
        /// <returns>success message</returns>
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
        /// <returns>string message</returns>
        [HttpPut]
        [Route("pinOrUnpin")]
        public IActionResult RetrieveNotesByPin(int id)
        {
            try
            {
                var result = this.notesManager.PinOrUnpin(id);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = result, Data = id });
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
