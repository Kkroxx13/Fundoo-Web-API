using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
   public class Notes
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }
        public bool IsPin { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime AddReminder { get; set; }      
        public bool IsArchive { get; set; }
        public bool IsNote { get; set; }
        public bool IsTrash { get; set; }        
        public long UserId { get; set; }     /// foreign key..               

        public IList<Collaboration> Collaborations { get; set; }
        public IList<Label> Labels { get; set; }


    }
}
