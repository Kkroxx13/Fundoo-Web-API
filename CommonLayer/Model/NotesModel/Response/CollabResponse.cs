﻿
using System;
using System.Collections.Generic;
using System.Text;


namespace CommonLayer.Model.NotesModel.Response
{
    public class CollabResponse
    {
        public long UserId { get; set; }
        public int NotesId { get; set; }
        public int CollaboratorId { get; set; }
    }
}
