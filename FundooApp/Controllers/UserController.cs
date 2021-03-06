﻿// --------------------------------------------------------------------------------------------------------------------
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
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// UserController class 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The user
        /// </summary>
        private readonly IUserManager user;

        /// <summary>
        /// The logger
        /// </summary>
        private ILog logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userManager">user manager.</param>
        public UserController(IUserManager userManager, ILog logger)
        {
            this.user = userManager;
            this.logger = logger; 
        }

        /// <summary>
        /// Registrations for registration the specified user.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>response data</returns>
        [HttpPost]
        [Route("registerEmployee")]
        public ActionResult Registration([FromBody]RegisterModel model)
        {
            try
            {
                var result = this.user.Register(model);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<RegisterModel>() { Status = true, Message = "Add new User Sucessfully", Data = model });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to add new user data" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// LoginEmployee for the existing user
        /// </summary>
        /// <param name="model">model as parameter</param>
        /// <returns>response data</returns>
        [HttpPost]
        [Route("loginEmployee")]
        public ActionResult LoginEmployee([FromBody] LoginModel model)
        {
            try
            {
                logger.Information("Information is logged");
                logger.Warning("Warnning is logged");
                logger.Debug("Debgue is logged");
                logger.Error("Error is logged");
                var result = this.user.Login(model.Email, model.Password);
                if (result.Equals(true))
                {
                    string token = this.user.GenerateToken(model.Email);
                    return this.Ok(new { Status = true, Message = "Login Sucessfully", Data = model, token });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to login the user :Email or Password mismatched" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Forgot the password.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>response data</returns>
        [HttpPost]
        [Route("forgetPassword")]
        public IActionResult ForgotPassword(string emailAddress)
        {
            try
            {
                var result = this.user.SendEmail(emailAddress);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Mail Sent Sucessfully", Data = emailAddress });
                }
                return this.BadRequest(new { Status = false, Message = "Email is not correct:Please enter valid email" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Resets the password employee.
        /// </summary>
        /// <param name="resetPassword">The reset password.</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("resetPassword")]
        public IActionResult ResetPasswordEmployee([FromBody] ResetPassword resetPassword)
        {
            try
            {
                var result = this.user.ResetPassword(resetPassword);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<ResetPassword>() { Status = true, Message = "Reset Password Link Sent Sucessfully", Data = resetPassword });
                }
                return this.BadRequest(new { Status = false, Message = "Failed to reset password:Email not exist in database or password is not matched" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}
