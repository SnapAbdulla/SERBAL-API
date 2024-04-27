using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serbal.Models;

namespace Serbal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickUpRequestController : ControllerBase
    {

        private readonly xyzContext context;
        public PickUpRequestController(xyzContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<PickUpRequest>>> GetPickUpRequest()
        {
            var data = await context.PickUpRequests.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PickUpRequest>> GetPickUpRequestID(int id)
        {
            var pickUpRequest = await context.PickUpRequests.FindAsync(id);
            if (pickUpRequest == null)
            {
                return NotFound();
            }
            return Ok(pickUpRequest);
        }
        [HttpPost]
        public async Task<ActionResult<PickUpRequest>> CreatePickUpRequest(PickUpRequest pickUpRequest)
        {
            await context.PickUpRequests.AddAsync(pickUpRequest);
            await context.SaveChangesAsync();
            return Ok(pickUpRequest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PickUpRequest>> UpdatePickUpRequest(int id, PickUpRequest PickUpRequest)
        {
            if (id != PickUpRequest.PickupID)
            {
                return BadRequest();
            }
            context.Entry(PickUpRequest).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(PickUpRequest);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<PickUpRequest>> DeletePickUpRequest(int id)
        {
            var locationPoint = await context.PickUpRequests.FindAsync(id);
            if (locationPoint == null)
            {
                return NotFound();
            }
            context.PickUpRequests.Remove(locationPoint);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
