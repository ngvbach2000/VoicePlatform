using VoicePlatform.Application.Configurations.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    public class PingsController : ControllerBase
    {
        [HttpGet]
        [Route("Ping")]
        public IActionResult GetPing()
        {
            var result = new
            {
                Status = "Ping!!!",
            };
            return StatusCode(200, result);
        }

        [HttpGet]
        [Route("Pong")]
        public IActionResult GetPong()
        {
            var result = new
            {
                Status = "Pong!!!",
            };
            return StatusCode(200, result);
        }
    }
}
