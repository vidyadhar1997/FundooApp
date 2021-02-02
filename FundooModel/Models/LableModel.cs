﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LableModel.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Vidyadhar Suresh Hudge"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>
    /// LableModel class
    /// </summary>
    public class LableModel
    {
        /// <summary>
        /// Gets or sets the lable identifier.
        /// </summary>
        /// <value>
        /// The lable identifier.
        /// </value>
        [Key]
        public int LableId { get; set; }

        /// <summary>
        /// Gets or sets the lable.
        /// </summary>
        /// <value>
        /// The lable.
        /// </value>
        public string Lable { get; set; }
    }
}