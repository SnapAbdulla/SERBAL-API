using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serbal.Models;

namespace Serbal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupMstController : ControllerBase
    {
        private readonly xyzContext context;
        public LookupMstController(xyzContext context)
        {
            this.context = context;
        }

        [HttpGet("{LookupType}")]
        public async Task<ActionResult<LookupMst>> GetEmployeeType(String LookupType)
        {
            var lookupMst = await context.LookupMst.FindAsync(LookupType);
            if (lookupMst == null)
            {
                return NotFound();
            }
            return Ok(lookupMst);
        }

    }
}
