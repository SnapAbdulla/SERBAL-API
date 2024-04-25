using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serbal.Models;

namespace Serbal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly xyzContext context;

        public RoleController(xyzContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleMst>>> GetRoles()
        { 
            var data= await context.RoleMsts.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleMst>> GetRoleByID(int id)
        {
            var RoleMst = await context.RoleMsts.FindAsync(id);
            if(RoleMst == null)
            {
                return NotFound();
            }
            return Ok(RoleMst);
        }

        [HttpPost]
        public async Task<ActionResult<RoleMst>> CreateRole(RoleMst roleMst)
        {
            await context.RoleMsts.AddAsync(roleMst);
            await context.SaveChangesAsync();
            return Ok(roleMst);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RoleMst>> UpdateRole(int id, RoleMst roleMst)
        {
            if (id != roleMst.RoleId)
            {
                return BadRequest();
            }
            context.Entry(roleMst).State=EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(roleMst); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RoleMst>> DeleteRole(int id)
        { 
            var roleMst=await context.RoleMsts.FindAsync(id);
            if (roleMst == null)
            {
                return NotFound();
            }
            context.RoleMsts.Remove(roleMst);
            await context.SaveChangesAsync();
            return Ok();
            
        }
    }
}
