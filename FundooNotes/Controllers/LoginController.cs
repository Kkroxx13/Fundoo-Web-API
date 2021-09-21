using BusinessLibrary.Interface;
using BusinessLibrary.Services;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("api/loginModel")]

    [ApiController]
    public class LoginController : Controller
    {
        private IUserBL userBL;
        public LoginController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        //POST:api/loginModel
       
        
        [HttpPost]

        public IActionResult Post(LoginModel loginModel)
        {

            if (loginModel == null)
            {
                return BadRequest("Employee is null.");
            }
             User user=userBL.Get(loginModel);
           
            if(user.Email==loginModel.Email && user.Password == loginModel.Password)
            {
                return this.Ok(new { success = true, message = "User successfully LoggedIn" });
            }
            else
            {
                return this.BadRequest();
            }

            
            //if (result ==loginModel.Email)
            //{
            //    return this.Ok(new { success = true, message = "User successfully LoggedIn" });
            //}
            //else
            //{
            //    return this.BadRequest();
            //}


        }
    }
}
