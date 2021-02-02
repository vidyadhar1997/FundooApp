// <copyright file="UserContext.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Context
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooModel.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// UserContext class
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class UserContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public UserContext(DbContextOptions options) : base(options)
        {
        }
        
        /// <summary>
        /// Gets or sets the register models.
        /// </summary>
        /// <value>
        /// The register models.
        /// </value>
        public DbSet<RegisterModel> Register_Models { get; set; }

        /// <summary>
        /// Gets or sets the notes models.
        /// </summary>
        /// <value>
        /// The notes models.
        /// </value>
        public DbSet<NotesModel> Note_model { get; set; }

        /// <summary>
        /// Gets or sets the lable models.
        /// </summary>
        /// <value>
        /// The lable models.
        /// </value>
        public DbSet<LableModel> Lable_Models { get; set; }


        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
