using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serbal.Models;
using Serbal.Utility;
using System.Linq;
using static System.Net.WebRequestMethods;

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
            if (user.Password != changePasswordModel.CurrentPassword)
            {
                return BadRequest("Incorrect Password");

            }
            user.Password = changePasswordModel.NewPassword;
            _context.SaveChanges();

            return Ok("Password changed successfully");
        }

        [HttpPut("ValidateOtp")]
        public IActionResult ValidateOtp(string userName)
        {
            try
            {
                int otp = OTPManager.GenerateOTP(userName);
                SentOTP.SendOTP(otp, userName);
                return Ok("OTP generated and sent successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request: " + ex.Message);
            }
        }


        [HttpPut("ForgetPassword")]
        public async Task<bool> ForgetPassword([FromBody] ForgotPassword forgetPasswordModel)
        {
            try
            {
                var user = _context.UserMsts.FirstOrDefault(u => u.UserName == forgetPasswordModel.UserName);
                if (user != null)
                {
                    if (OTPManager.ValidateOTP(forgetPasswordModel.UserName, forgetPasswordModel.otp))
                    {
                        if (forgetPasswordModel.enterPassword == forgetPasswordModel.reenterPassword && user.Password != forgetPasswordModel.enterPassword)
                        {
                            user.Password = forgetPasswordModel.enterPassword;
                            await _context.SaveChangesAsync();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred while processing the request: " + ex.Message);
                return false;
            }
        }
    }
}


