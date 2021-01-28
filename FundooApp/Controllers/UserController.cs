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
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModel.Models;
    using Microsoft.AspNetCore.Authorization;
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
        /// Registrations for registration the specified user.
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

        /// <summary>
        /// LoginEmployee for the existing user
        /// </summary>
        /// <param name="model">model as parameter</param>
        /// <returns>login success message</returns>
        [HttpPost]
        [Route("api/fundooLogin")]
        public ActionResult LoginEmployee([FromBody] LoginModel model)
        {
            string message = "LOGIN SUCCESS";
            var result = this.user.Login(model.Email, model.Password);
            if (result.Equals(message))
            {
                string token = this.user.GenerateToken(model.Email);
                return this.Ok(new { sucess = true, message = "Login sucessfully", data = result, token });
            }
            else
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Forgot the password.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>success message</returns>
        [HttpPost]
        [Route("api/forgetPassword")]
        public IActionResult ForgotPassword(string emailAddress)
        {
            var result = this.user.SendEmail(emailAddress);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Password Reset link Sent Successfully", Data = result });
            }
            else
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Resets the password employee.
        /// </summary>
        /// <param name="resetPassword">The reset password.</param>
        /// <returns>success message</returns>
        [HttpPut]
        [Route("api/ResetPassword")]
        public IActionResult ResetPasswordEmployee([FromBody] ResetPassword resetPassword)
        {
            var result = this.user.ResetPassword(resetPassword);
            if (result.Equals("SUCCESS"))
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
