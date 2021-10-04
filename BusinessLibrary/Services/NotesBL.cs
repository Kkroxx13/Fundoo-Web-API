using BusinessLayer.Interface;
using CommonLayer.Model.NotesModel;
using CommonLayer.Model.NotesModel.Request;
using CommonLayer.Model.NotesModel.Response;
using Microsoft.AspNetCore.Http;
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

        

        public bool CreateNotes(AddNotesRequestModel model, long userId)
        {
            return _notesRL.CreateNotes(model,userId);
        }

        public bool Delete(Notes notes)
        {
            try
            {
                return this._notesRL.Delete(notes);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Notes> DisplayNotes()
        {
            try
            {
                return this._notesRL.DisplayNotes();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool EditNotes(EditNotesModel editNotesModel, long Id)
        {
            try
            {
                return this._notesRL.EditNotes(editNotesModel,Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Notes Get(long Id)
        {
            try
            {
                return this._notesRL.Get(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool ArchiveNote(IsArchiveModel isArchiveModel, long Id)
        {
            try
            {
                return this._notesRL.ArchiveNote(isArchiveModel,Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool ChangeColor(long Id, ChangeColorModel changeColorModel)
        {
            try
            {
                return this._notesRL.ChangeColor(Id, changeColorModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool PinNote(long Id)
        {
            try
            {
                return this._notesRL.PinNote(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool TrashNote(long Id)
        {
            try
            {
                return this._notesRL.TrashNote(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       

        public bool AddReminder(long Id, AddReminderModel addReminderModel)
        {
            try
            {
                return this._notesRL.AddReminder(Id,addReminderModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool UploadImage(IFormFile file, int Id)
        {
            try
            {
                return this._notesRL.UploadImage(file, Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool AddCollaborators(int Id, AddCollaboratorResponse collaborator)
        {
            try
            {
                return this._notesRL.AddCollaborators(Id, collaborator);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CollabResponse> GetAllCollabs(long UserId)
        {
            return _notesRL.GetAllCollabs(UserId);
        }

    }
}
