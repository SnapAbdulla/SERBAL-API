using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serbal.Models;

namespace Serbal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMstController : ControllerBase
    {
        private readonly xyzContext context;
        public EmployeeMstController(xyzContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<EmployeeMst>>> GetEmployeeMst()
        {
            var data = await context.EmployeeMsts.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeMst>> GetEmployeeMstID(int id)
        {
            var employeeMst= await context.EmployeeMsts.FindAsync(id);
            if (employeeMst == null)
            {
                return NotFound();
            }
            return Ok(employeeMst);
        }
        [HttpPost]
        public async Task<ActionResult<EmployeeMst>> CreateEmployeeMst(EmployeeMst EmployeeMst)
        {
            await context.EmployeeMsts.AddAsync(EmployeeMst);
            await context.SaveChangesAsync();
            return Ok(EmployeeMst);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeMst>> UpdateEmployeeMst(int id, EmployeeMst EmployeeMst)
        {
            if (id != EmployeeMst.EmployeeID)
            {
                return BadRequest();
            }
            context.Entry(EmployeeMst).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(EmployeeMst);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeMst>> DeleteEmployeeMst(int id)
        {
            var EmployeeMst = await context.EmployeeMsts.FindAsync(id);
            if (EmployeeMst == null)
            {
                return NotFound();
            }
            context.EmployeeMsts.Remove(EmployeeMst);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
