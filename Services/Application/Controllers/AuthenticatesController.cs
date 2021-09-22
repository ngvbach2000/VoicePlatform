using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VoicePlatform.Data.Application;
using VoicePlatform.Data.Entities;
using VoicePlatform.Data.Requests;
using VoicePlatform.Service.Interfaces;

namespace VoicePlatform.Application.Controllers
{
    [ApiController]
    public class AuthenticatesController : ControllerBase
    {
        private readonly IAuthenticateService _service;

        public AuthenticatesController(IAuthenticateService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<Response> Authenticate([FromBody] AuthenticateRequest user)
        {
            return await _service.Authenticate(user);
        }
    }
}
