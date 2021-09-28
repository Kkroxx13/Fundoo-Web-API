using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model.NotesModel
{
   public class AddCollaborator
    {
        [Required]
        public int NoteId { get; set; }
        [Required]
        public int CollaboratorId { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
    }
}
