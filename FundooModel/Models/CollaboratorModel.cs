using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModel.Models
{
    public class CollaboratorModel
    {
        [Key]
        public int CollaboratorId { get; set; }

        [ForeignKey("NotesModel")]
        public int NoteId { get; set; }

        public string SenderEmail { get; set; }

        public string ReceiverEmail { get; set; }
    }
}
