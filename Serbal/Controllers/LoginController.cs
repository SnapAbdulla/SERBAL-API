using Microsoft.AspNetCore.Mvc;
using Serbal.Models;
using System.Linq;

namespace Serbal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly xyzContext _context;

        public LoginController(xyzContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<UserMst> Login([FromBody] LoginModel loginModel)
        {
            var user = _context.UserMsts.FirstOrDefault(u => u.UserName == loginModel.UserName && u.Password == loginModel.Password);

            if (user == null)
            {
                return NotFound("Invalid username or password");
            }

            return Ok(user);
        }
        [HttpPost("ChangePassword")]
        public ActionResult ChangePassword([FromBody] ChangePasswordModel changePasswordModel)
        {
            var user = _context.UserMsts.FirstOrDefault(u => u.UserName == changePasswordModel.UserName);
            if (user == null)
            {
                return NotFound("User not found ");
            }
            if(user.Password != changePasswordModel.CurrentPassword)
            {
                return BadRequest("Incorrect Password");

            }
            user.Password = changePasswordModel.NewPassword;
            _context.SaveChanges();

            return Ok("Password changed successfully");
        }
    }
}
