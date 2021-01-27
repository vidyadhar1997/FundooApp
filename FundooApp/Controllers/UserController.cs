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
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using FundooManager.Interface;
    using FundooModel.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;

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
        private const string SECRET_KEY = "this is my custom Secret key for authnetication";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(UserController.SECRET_KEY));

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
                string token=GenerateToken(model.Email);
                return this.Ok(new { sucess=true,message="Login sucessfully",data=result,token});
            }
            else
            {
                return this.BadRequest();
            }
        }

        private string GenerateToken(string userEmail)
        {
            var token = new JwtSecurityToken(
            claims: new Claim[]
            {
                new Claim(ClaimTypes.Name, userEmail)
            },
            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
            expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
            signingCredentials: new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
