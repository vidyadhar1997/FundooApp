// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LableController.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooApp.Controllers
{
    using FundooManager.Interface;
    using FundooModel.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// LableController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class LableController : ControllerBase
    {
        /// <summary>
        /// The lable manager
        /// </summary>
        private readonly ILableManager lableManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableController"/> class.
        /// </summary>
        /// <param name="lableManager">The lable manager.</param>
        public LableController(ILableManager lableManager)
        {
            this.lableManager = lableManager;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>response data</returns>
        [HttpPost]
        public ActionResult AddLables([FromBody] LableModel model)
        {
            try
            {
                string result = this.lableManager.AddLable(model);
                if (result.Equals("ADD LABLE SUCCESSFULL"))
                {
                    return this.Ok(new ResponseModel<LableModel>() { Status = true, Message = result, Data = model });

                }
                return this.BadRequest(new { Status = false, Message = "Failed to Add Lable" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves all lables.
        /// </summary>
        /// <returns>response data</returns>
        [HttpGet]
        public IActionResult RetrieveAllLables()
        {
            try
            {
                IEnumerable<LableModel> result = this.lableManager.RetrieveLables();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<LableModel>>() { Status = true, Message = "Retrieve Lables Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Lables" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves the lables by identifier.
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>response data</returns>
        [HttpGet]
        [Route("retrieveLablesById")]
        public IActionResult RetrieveLablesById(int id)
        {
            try
            {
                LableModel result = this.lableManager.RetrieveLableById(id);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<LableModel>() { Status = true, Message = "Retrieve Lable By Id Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Failed to Retrieve Lable By id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        /// <summary>
        /// Deletes the lable.
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>response data</returns>
        [HttpDelete]
        public IActionResult DeleteLable(int id)
        {
            try
            {
                var result = this.lableManager.RemoveLable(id);
                if (result.Equals("LABLE DELETED SUCCESSFULL"))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = result, Data = id });
                }
                return this.BadRequest(new { Status = false, Message = "Unable to delete lable : Enter valid Id" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Updates the lables.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>response data</returns>
        [HttpPut]
        public IActionResult UpdateLables([FromBody] LableModel model)
        {
            try
            {
                var result = this.lableManager.UpdateLables(model);
                if (result.Equals("UPDATE LABLE SUCCESSFULL"))
                {
                    return this.Ok(new ResponseModel<LableModel>() { Status = true, Message = result, Data = model });
                }
                return this.BadRequest(new { Status = false, Message = "Error while updating lables" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

    }
}
