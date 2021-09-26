using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommonLayer.Model.NotesModel;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/notes")]

    [ApiController]
    public class NotesController : Controller
    {
        private readonly INotesBL _notesBL;
        public NotesController(INotesBL notesBL)
        {
            _notesBL = notesBL;
        }

        [HttpGet("getnotes")]
        public IActionResult DisplayNotes()
        {
            IEnumerable<Notes> notes = _notesBL.DisplayNotes();
            return Ok(notes);
        }

        [HttpPost("createnotes")]
        public IActionResult CreateNotes(AddNotesRequestModel model)
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
    }
}
