// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
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
    /// UserController class 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The user
        /// </summary>
        private readonly IUserManager user;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public UserController(IUserManager userManager)
        {
            this.user = userManager;
        }
        
        /// <summary>
        /// Registrations the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns> ok result if condition getting matched</returns>
        [HttpPost]
        [Route("api/fundooRegistration")]
        public ActionResult Registration([FromBody]RegisterModel model)
        {
            string result = this.user.Register(model);
            if (result == "SUCCESS")
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }
    }
}
