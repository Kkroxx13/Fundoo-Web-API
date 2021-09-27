using CommonLayer.Model.NotesModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INotesRL
    {
        bool CreateNotes(AddNotesRequestModel model);
        IEnumerable<Notes> DisplayNotes();
        Notes Get(long Id);
        bool Delete(Notes notes);
        bool EditNotes(EditNotesModel editNotesModel, long Id);
        bool ArchiveNote(IsArchiveModel isArchiveModel, long Id);
        bool ChangeColor(long Id, ChangeColorModel changeColorModel);
        bool PinNote(long Id);
        bool TrashNote(long Id);
    }
}
