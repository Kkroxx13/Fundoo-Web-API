using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model.NotesModel
{
    public class AddReminderModel
    {
        [Required]
        public DateTime AddReminder { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}
