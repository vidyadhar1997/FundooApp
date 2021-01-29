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
        [Route("api/fundooAddNotes")]
        public ActionResult AddNotes([FromBody] NotesModel model)
        {
            string message = "ADD NOTES SUCCESSFULL";
            string result = this.notesManager.AddNotes(model);
            if (result.Equals(message))
            {
                return this.Ok(new { success = true, message = "Add notes successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Failed to Add Notes" });
            }
        }

        /// <summary>
        /// RetrieveNotes to retrieve all the notes
        /// </summary>
        /// <returns>success message</returns>
        [HttpGet]
        [Route("api/retrieveNotes")]
        public IActionResult RetrieveNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.RetrieveNotes();
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        /// <summary>
        /// DeleteNotes for delete specific notes
        /// </summary>
        /// <param name="id">notes id</param>
        /// <returns>notes deleted message</returns>
        [HttpDelete]
        [Route("api/deletedNotes")]
        public IActionResult DeleteNotes(int id)
        {
            string message = "NOTES DELETED SUCCESSFULL";
            var result = this.notesManager.RemoveNote(id);
            if (result.Equals(message))
            {
                return this.Ok(new { success = true, message = "Notes deleted successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Notes Id is not prsent in database" });
            }
        }

        /// <summary>
        /// UpdateNotes for updating notes
        /// </summary>
        /// <param name="model">notes model</param>
        /// <returns>success message</returns>
        [HttpPut]
        [Route("api/updateNotes")]
        public IActionResult UpdateNotes([FromBody] NotesModel model)
        {
            string message = "UPDATE SUCCESSFULL";
            var result = this.notesManager.UpdateNotes(model);
            if (result.Equals(message))
            {
                return this.Ok(new { success = true, message = "Update notes successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Notes Id is not prsent in database" });
            }
        }
    }
}
