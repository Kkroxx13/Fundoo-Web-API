using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model.NotesModel
{
    public class UploadImage
    {
        public IFormFile file { get; set; }
    }
}
