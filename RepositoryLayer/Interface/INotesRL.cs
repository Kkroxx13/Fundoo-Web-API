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
        IEnumerable<Notes> DisplayNotes(long userId);
        Notes Get(long Id, long userId);
        bool Delete(Notes notes);
        bool EditNotes(EditNotesModel editNotesModel, long Id, long userId);
        bool ArchiveNote(IsArchiveModel isArchiveModel, long Id, long userId);
        bool ChangeColor(long Id, ChangeColorModel changeColorModel, long userId);
        bool PinNote(long Id, long userId);
        bool TrashNote(long Id, long userId);
       
        bool AddReminder(long Id, AddReminderModel addReminderModel, long userId);
        bool UploadImage(IFormFile file, int Id, long userId);
        bool AddCollaborators(int Id, AddCollaboratorResponse collaborator, long userId);
        List<CollabResponse> GetAllCollabs(long UserId);
    }
}
