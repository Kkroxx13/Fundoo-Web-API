using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Model.NotesModel;
using CommonLayer.Model.NotesModel.Request;
using CommonLayer.Model.NotesModel.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL
    {
        readonly UserContext _userContext;
        IConfiguration _configuration;
        public NotesRL(UserContext context, IConfiguration configuration)
        {
            _userContext = context;
            _configuration = configuration;
        }
        public bool CreateNotes(AddNotesRequestModel model, long userId)
        {
            try
            {
                Notes notesEntity = new Notes();
                notesEntity.Id = model.Id;
                notesEntity.Title = model.Title;
                notesEntity.Message = model.Message;
                notesEntity.Image = model.Image;
                notesEntity.Color = model.Color;
                notesEntity.IsPin = model.IsPin;
                notesEntity.CreatedDate = DateTime.Now;
                notesEntity.ModifiedDate =DateTime.Now;
                notesEntity.AddReminder = model.AddReminder;
               
                notesEntity.IsArchive = model.IsArchive;
                notesEntity.IsNote = model.IsNote;
                notesEntity.IsTrash = model.IsTrash;
                notesEntity.UserId = userId;
                _userContext.Notes.Add(notesEntity);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Notes notes)
        {
            try
            {
                _userContext.Notes.Remove(notes);
                var result = _userContext.SaveChanges();

                if (result > 0)
                {
                    return true;

                }

                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Notes> DisplayNotes(long userId)
        {

            try
            {
                List<Notes> notes = _userContext.Notes.Where(x => x.UserId == userId).ToList();
                return notes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EditNotes(EditNotesModel editNotesModel, long Id, long userId)
        {
            Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id && e.UserId==userId);
            try
            {

                //notes.Id = editNotesModel.Id;
                notes.Title = editNotesModel.Title;
                notes.Message = editNotesModel.Message;
                notes.Image = editNotesModel.Image;
                notes.Color = editNotesModel.Color;
                notes.ModifiedDate = editNotesModel.ModifiedDate;
                _userContext.Notes.Update(notes);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        

        public Notes Get(long Id, long userId)
        {
            try
            {
                return _userContext.Notes.FirstOrDefault(e => e.Id == Id && e.UserId==userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public bool ArchiveNote(IsArchiveModel isArchiveModel, long Id, long userId)
        {
            try
            {
                Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id && e.UserId==userId);
                if (notes.IsArchive == false)
                {

                    notes.IsArchive = true;

                }
                else
                {

                    notes.IsArchive = false;

                }
                _userContext.Notes.Update(notes);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ChangeColor(long Id, ChangeColorModel changeColorModel, long userId)
        {
            try
            {
                Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id && e.UserId==userId);
                notes.Color = changeColorModel.Color;
                


                _userContext.Notes.Update(notes);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool PinNote(long Id, long userId)
        {
            try
            {
                Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id && e.UserId==userId);
                if (notes.IsPin == false)
                {

                    notes.IsPin = true;

                }
                else
                {

                    notes.IsPin = false;

                }
                _userContext.Notes.Update(notes);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        
        public bool TrashNote(long Id, long userId)
        {
            try
            {
                Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id && e.UserId==userId);
                if (notes.IsTrash == false)
                {

                    notes.IsTrash = true;

                }
                else
                {

                    notes.IsTrash = false;

                }
                _userContext.Notes.Update(notes);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public bool AddReminder(long Id, AddReminderModel addReminderModel, long userId)
        {
            
            try
            {
                Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id && e.UserId==userId);
                notes.AddReminder = addReminderModel.AddReminder;
                notes.ModifiedDate = DateTime.Now;



                _userContext.Notes.Update(notes);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

       
        public bool UploadImage(IFormFile file, int Id, long userId)
        {
            try
            {
                Account account = new Account(
                    "selg",
                    "968789572864694",
                    "gefKxEXzG727bRz5mBN3bUww9gA");
                var Path = file.OpenReadStream();
                Cloudinary cloudinary = new Cloudinary(account);
                cloudinary.Api.Secure = true;

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, Path)
                   
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                

                Notes notes = _userContext.Notes.FirstOrDefault(e => e.Id == Id && e.UserId==userId);
                notes.Image = uploadResult.Url.ToString();
                _userContext.Notes.Update(notes);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool AddCollaborators(int Id, AddCollaboratorResponse collaborator, long userId)
        {
            Collaboration collaboration = new Collaboration();
            collaboration.UserId = userId;
            collaboration.Id = Id;
            collaboration.CreatedAt = DateTime.Now;
            collaboration.CollaborationId = collaborator.CollaboratorId;
            _userContext.Collaborations.Add(collaboration);
            int result = _userContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<CollabResponse> GetAllCollabs(long UserId)
        {
            List<CollabResponse> allCollabs = _userContext.Collaborations.Where(collab => collab.UserId == UserId).
                Select(collabs => new CollabResponse
                {
                    UserId=collabs.UserId,
                    NotesId=collabs.Id,
                    CollaboratorId=collabs.CollaborationId
                  
                    
                }).ToList();
            return allCollabs;
        }
    }
}
