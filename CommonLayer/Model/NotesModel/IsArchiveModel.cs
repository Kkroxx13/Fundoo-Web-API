using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model.NotesModel
{
    public class IsArchiveModel
    {
        [Required]
        public bool IsArchive { get; set; }
    }
}
