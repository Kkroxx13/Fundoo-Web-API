
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryLayer.Interface;
using RepositoryLayer.Entity;
using CommonLayer.Model;
using BusinessLibrary.Interface;

namespace FundooNotes.Controllers
{
    [Route("api/user")]
    
    [ApiController]
    public class UserController : Controller
    {
        private IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        // GET: api/user
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> user = userBL.GetAll();
            return Ok(user);
        }
        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            User user = userBL.Get(id);
            if (user == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            return Ok(user);
        }
        // POST: api/user
        [HttpPost]
        public IActionResult Post(RegisterModel user)
        {
            if (user == null)
            {
                return BadRequest("Employee is null.");
            }
            var result = userBL.Add(user);
            if (result == true)
            {
                return this.Ok(new { success = true, message = "User successfully Registered" });
            }
            else
            {
                return this.BadRequest();
            }
            //return CreatedAtRoute(
            //      "Get",
            //      new { Id = user.UserId },
            //      user);
        }

        
       
        
    }
        





        // PUT: api/Employee/5
        //[HttpPut("{id}")]
        //public IActionResult Put(long id, [FromBody] User user)
        //{
        //    if (user == null)
        //    {
        //        return BadRequest("Employee is null.");
        //    }
        //    User userToUpdate = userBL.Get(id);
        //    if (userToUpdate == null)
        //    {
        //        return NotFound("The Employee record couldn't be found.");
        //    }
        //    userBL.Update(userToUpdate, user);
        //    return NoContent();
        //}
        // DELETE: api/Employee/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(long id)
        //{
        //    User user = userBL.Get(id);
        //    if (user == null)
        //    {
        //        return NotFound("The Employee record couldn't be found.");
        //    }
        //    userBL.Delete(user);
        //    return NoContent();
        //}
    
}
