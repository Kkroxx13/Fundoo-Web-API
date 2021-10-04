using CommonLayer.Model.NotesModel;
using CommonLayer.Model.NotesModel.Request;
using CommonLayer.Model.NotesModel.Response;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INotesRL
    {
        bool CreateNotes(AddNotesRequestModel model, long userId);
        IEnumerable<Notes> DisplayNotes();
        Notes Get(long Id);
        bool Delete(Notes notes);
        bool EditNotes(EditNotesModel editNotesModel, long Id);
        bool ArchiveNote(IsArchiveModel isArchiveModel, long Id);
        bool ChangeColor(long Id, ChangeColorModel changeColorModel);
        bool PinNote(long Id);
        bool TrashNote(long Id);
       
        bool AddReminder(long Id, AddReminderModel addReminderModel);
        bool UploadImage(IFormFile file, int Id);
        bool AddCollaborators(int Id, AddCollaboratorResponse collaborator);
        List<CollabResponse> GetAllCollabs(long UserId);
    }
}
