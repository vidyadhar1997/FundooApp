using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModel.Models
{
    public class Collaborator
    {
        [Key]
        public int CollaboratorId { set; get; }

        public int NoteId { get; set; }

        [ForeignKey("LoginModel")]
        public string Email { get; set; }

        public string RecieverEmail { get; set; }

    }
}
