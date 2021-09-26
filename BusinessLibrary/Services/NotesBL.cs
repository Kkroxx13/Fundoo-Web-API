using BusinessLayer.Interface;
using CommonLayer.Model.NotesModel;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class NotesBL : INotesBL
    {
        INotesRL _notesRL;
        public NotesBL(INotesRL notesRL)
        {
            _notesRL = notesRL;
        }
        public bool CreateNotes(AddNotesRequestModel model)
        {
            return _notesRL.CreateNotes(model);
        }

        public IEnumerable<Notes> GetAll()
        {
            try
            {
                return this._notesRL.GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
