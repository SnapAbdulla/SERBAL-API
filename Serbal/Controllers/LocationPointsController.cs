using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serbal.Models;

namespace Serbal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationPointsController : ControllerBase
    {

        private readonly xyzContext context;
        public LocationPointsController(xyzContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<LocationPoint>>> GetLocatioPoints()
        {
            var data = await context.LocationPoints.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationPoint>> GetLocationPointID(int id)
        {
            var locationPoint = await context.LocationPoints.FindAsync(id);
            if (locationPoint == null)
            {
                return NotFound();
            }
            return Ok(locationPoint);
        }
        [HttpPost]
        public async Task<ActionResult<LocationPoint>> CreateLocationPoint(LocationPoint locationPoint)
        {
            await context.LocationPoints.AddAsync(locationPoint);
            await context.SaveChangesAsync();
            return Ok(locationPoint);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LocationPoint>> UpdateLocationPoint(int id, LocationPoint locationPoint)
        {
            if (id != locationPoint.LocationID)
            {
                return BadRequest();
            }
            context.Entry(locationPoint).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(locationPoint);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<LocationPoint>> DeleteLocationPoint(int id)
        {
            var  locationPoint= await context.LocationPoints.FindAsync(id);
            if (locationPoint == null)
            {
                return NotFound();
            }
            context.LocationPoints.Remove(locationPoint);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
