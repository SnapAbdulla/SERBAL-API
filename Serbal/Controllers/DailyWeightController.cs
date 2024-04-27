using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serbal.Models;

namespace Serbal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyWeightController : ControllerBase
    {
        private readonly xyzContext context;
        public DailyWeightController(xyzContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<DailyWeight>>> GetDailyWeight()
        {
            var data = await context.DailyWeights.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DailyWeight>> GetDailyWeightID(int id)
        {
            var dailyWeight = await context.DailyWeights.FindAsync(id);
            if (dailyWeight == null)
            {
                return NotFound();
            }
            return Ok(dailyWeight);
        }
        [HttpPost]
        public async Task<ActionResult<DailyWeight>> CreateDailyWeight(DailyWeight dailyWeight)
        {
            await context.DailyWeights.AddAsync(dailyWeight);
            await context.SaveChangesAsync();
            return Ok(dailyWeight);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DailyWeight>> UpdateDailyWeight(int id, DailyWeight dailyWeight)
        {
            if (id != dailyWeight.WeightID)
            {
                return BadRequest();
            }
            context.Entry(dailyWeight).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(dailyWeight);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<DailyWeight>> DeleteDailyWeight(int id)
        {
            var dailyWeight = await context.DailyWeights.FindAsync(id);
            if (dailyWeight == null)
            {
                return NotFound();
            }
            context.DailyWeights.Remove(dailyWeight);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
