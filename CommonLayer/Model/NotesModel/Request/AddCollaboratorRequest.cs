using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model.NotesModel.Request
{
    public class AddCollaboratorRequest
    {
        [Required]
        public int CollaboratorId { get; set; }
    }
}
