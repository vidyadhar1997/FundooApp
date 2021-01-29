using FundooManager.Interface;
using FundooModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooApp.Controllers
{
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
        /// <returns></returns>
        [HttpPost]
        [Route("api/fundooAddNotes")]
        public ActionResult AddNotes([FromBody] NotesModel model)
        {
            string message = "INSERT DATA SUCCESSFULL";
            string result = this.notesManager.AddNotes(model);
            if (result.Equals(message))
            {
                return this.Ok(new { success = true, message = "INSERT DATA SUCCESSFULL" });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Failed to Insert Data to Database" });
            }
        }

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
    }
}
