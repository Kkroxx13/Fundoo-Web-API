using CommonLayer.Model.NotesModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
   public interface INotesBL
    {
        bool CreateNotes(AddNotesRequestModel model);
        IEnumerable<Notes> GetAll();
    }
}
