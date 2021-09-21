using CommonLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryLayer.Interface;

namespace FundooNotes.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IRL<User> _rl;
        public UserController(IRL<User> rL)
        {
            _rl = rL;
        }

        // GET: api/user
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> employees = _rl.GetAll();
            return Ok(employees);
        }
        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            User user = _rl.Get(id);
            if (user == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            return Ok(user);
        }
        // POST: api/user
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Employee is null.");
            }
            _rl.Add(user);
            return CreatedAtRoute(
                  "Get",
                  new { Id = user.UserId },
                  user);
        }
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Employee is null.");
            }
            User userToUpdate = _rl.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            _rl.Update(userToUpdate, user);
            return NoContent();
        }
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            User user = _rl.Get(id);
            if (user == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            _rl.Delete(user);
            return NoContent();
        }
    }
}
