using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundooNotesProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        //UserRegister
        [HttpPost]
        [Route ("Register")]
        public IActionResult UserRegister(UserRegModel model)
        {
            try
            {
                var result = userBusiness.UserRegister(model);
                if (result != null)
                {
                    return Ok(new { success = true, message = "User Registered Successfully", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "User Not Registered" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        //UserLogin
        [HttpPost]
        [Route ("Login")]
        public IActionResult UserLogin(UserLogModel model)
        {
            try
            {
                var result = userBusiness.UserLogin(model);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Login Successful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Login Unsuccessful" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
