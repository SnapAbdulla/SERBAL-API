using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Serbal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsAPIController : ControllerBase
    {
        public List<string> Fruits = new List<string>()
        {
            "Apple",
            "Banana",
            "Mango",
            "Cherry",
            "Grapes"
        };

        [HttpGet]
        public List<string> GetFruits()
        { 
            return Fruits;
        }

        [HttpGet("{id}")]
        public string GetFruits(int id)
        {
            return Fruits.ElementAt(id);
        }
    }
}
