﻿using FundooManager.Interface;
using FundooModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooApp.Controllers
{
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
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddNotes([FromBody] LableModel model)
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
    }
}
