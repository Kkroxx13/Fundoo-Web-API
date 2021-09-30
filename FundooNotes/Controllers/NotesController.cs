using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommonLayer.Model.NotesModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/notes")]

    [ApiController]
    public class NotesController : Controller
    {
        public static IConfiguration _config;
        private readonly INotesBL _notesBL;
        public static IWebHostEnvironment _environment;
        public NotesController(INotesBL notesBL, IConfiguration config, IWebHostEnvironment environment)
        {
            _notesBL = notesBL;
            _config = config;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult DisplayNotes()
        {
            try
            {
                IEnumerable<Notes> notes = _notesBL.DisplayNotes();
                return Ok(notes);
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateNotes(AddNotesRequestModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Employee is null.");
                }
                var result = _notesBL.CreateNotes(model);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Note Created Successfully" });
                }
                else
                {
                    return this.BadRequest();
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }

        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteNotes(long Id)
        {
            try
            {
                Notes notes = _notesBL.Get(Id);
                if (notes == null)
                {
                    return NotFound("The Employee record couldn't be found.");
                }
                var result = _notesBL.Delete(notes);

                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Notes Deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Note Deletion Failed" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }


        }

        [HttpPut("{Id}/edit")]
        public IActionResult EditNotes(EditNotesModel editNotesModel,long Id)
        {

            try
            {
                
                var result = _notesBL.EditNotes(editNotesModel, Id);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Notes Edited Successfully" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Note Updation Failed" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }

        }

        [HttpPut("{Id}/archive")]
        public IActionResult ArchiveNote(IsArchiveModel isArchiveModel,long Id)
        {
            try
            {
               
                var result = _notesBL.ArchiveNote(isArchiveModel, Id);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "IsArchive function successfull" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "IsArchive function unsuccessfull" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPut("{Id}/color")]
        public IActionResult ChangeColor( ChangeColorModel changeColorModel,long Id)
        {
            try
            {
                
                var result = _notesBL.ChangeColor(Id, changeColorModel);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Color change successfull" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Color Change unsuccessfull" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }


        [HttpPut("{Id}/pin")]
        public IActionResult PinNote(long Id)
        {
            try
            {
                
                var result = _notesBL.PinNote(Id);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "IsPin function successfull" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "IsPin function unsuccessfull" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        
        [HttpPut("{Id}/trash")]
        public IActionResult TrashNote()
        {
            try
            {
                var Id = GetTokenId();
                var result = _notesBL.TrashNote(Id);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "IsTrash function successfull" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "IsTrash function unsuccessfull" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        
        [HttpPut("{Id}/reminder")]
        public IActionResult AddReminder( AddReminderModel addReminderModel,long Id)
        {
            try
            {
                
                var result = _notesBL.AddReminder(Id, addReminderModel);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Reminder Added Successfully " });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Reminder adding unsuccessfull" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPut("{Id}/upload")]
        public IActionResult UploadImage(IFormFile file,int Id)
        {
            try
            {

                var result = _notesBL.UploadImage(file,Id);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Image Added Successfully " });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Image adding unsuccessfull" });
                }
            }
            catch (Exception ex)
            {

                return this.BadRequest(new { success = false, message = ex.Message });
            }
        }



        // Get UserID by JWT Token
        private long GetTokenId()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }

        //Generate JWT Token
        private static string GenerateJwtToken(long UserId, string EmailId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim("Id", UserId.ToString()));
            permClaims.Add(new Claim(ClaimTypes.Email, EmailId));

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              permClaims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
