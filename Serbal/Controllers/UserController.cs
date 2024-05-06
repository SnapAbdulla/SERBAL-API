using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serbal.Models;

namespace Serbal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly xyzContext context;
        public UserController(xyzContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserMst>>> GetUser()
        {
            var data = await context.UserMsts.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserMst>> GetUserMstID(int id)
        {
            var userMst = await context.UserMsts.FindAsync(id);
            if (userMst == null)
            {
                return NotFound();
            }
            return Ok(userMst);
        }
        [HttpPost]
        public async Task<ActionResult<UserMst>> CreateUserMst(UserMst userMst)
        {
            await context.UserMsts.AddAsync(userMst);
            await context.SaveChangesAsync();
            return Ok(userMst);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserMst>> UpdateUserMst(int id, UserMst userMst)
        {
            if (id != userMst.UserID)
            {
                return BadRequest();
            }
            context.Entry(userMst).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(userMst);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserMst>> DeleteUserMst(int id)
        {
            var userMst = await context.UserMsts.FindAsync(id);
            if (userMst == null)
            {
                return NotFound();
            }
            context.UserMsts.Remove(userMst);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
