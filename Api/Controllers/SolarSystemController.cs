using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class SolarSystemController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Colé!");
    }
}
