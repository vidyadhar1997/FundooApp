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
    /// CollaboratorController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : ControllerBase
    {
        /// <summary>
        /// The collaborator manager
        /// </summary>
        private readonly ICollaboratorManager collaboratorManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableController"/> class.
        /// </summary>
        /// <param name="lableManager">The lable manager.</param>
        public CollaboratorController(ICollaboratorManager collaboratorManager)
        {
            this.collaboratorManager = collaboratorManager;
        }

        /// <summary>
        /// Adds the collaborators.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCollaborators([FromBody] CollaboratorModel model)
        {
            try
            {
                string result = this.collaboratorManager.AddCollaborator(model);
                if (result.Equals("NEW COLLABORATOR ADDED SUCCESSFULL"))
                {
                    return this.Ok(new ResponseModel<CollaboratorModel>() { Status = true, Message = result, Data = model });

                }
                return this.BadRequest(new { Status = false, Message = "Failed to Add Collaborator" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteCollaborator(int id)
        {
            try
            {
                var result = this.collaboratorManager.DeleteCollaborator(id);
                if (result.Equals("COLLABORATOR DELETED SUCCESSFULL"))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = result, Data = id });
                }
                return this.BadRequest(new { Status = false, Message = "Unable to delete collaborator : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves all collaborator.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RetrieveAllCollaborator()
        {
            try
            {
                IEnumerable<CollaboratorModel> result = this.collaboratorManager.GetCollaborator();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<CollaboratorModel>>() { Status = true, Message = "Retrieve Collaborator Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Collaborator" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}
