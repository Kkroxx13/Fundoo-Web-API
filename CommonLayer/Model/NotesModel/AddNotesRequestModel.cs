using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model.NotesModel
{
   public class AddNotesRequestModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public bool IsPin { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        [Required]
        public DateTime AddReminder { get; set; }
        [Required]
        public int UserId { get; set; }     /// foreign key..
        [Required]
        public bool IsArchive { get; set; }
        [Required]
        public bool IsNote { get; set; }
        [Required]
        public bool IsTrash { get; set; }
    }
}
