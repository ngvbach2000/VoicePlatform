//using Data.Request.Users;
//using Data.Requests.User;
//using Data.Response;
//using Data.Response.Users;
//using Data.Responses.User;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace Application.Controllers
//{
//    public class UsersController : ControllerBase
//    {
//        private readonly IUserService _service;

//        public UsersController(IUserService service)
//        {
//            _service = service;
//        }

//        [HttpPost]
//        [Route("Users/Authenticate")]
//        public async Task<ApplicationResponse<AuthenticateResponse>> Authenticate([FromBody] AuthenticateRequest model)
//        {
//            return await _service.Authenticate(model);
//        }

//        [HttpPost]
//        [Route("Users/Register")]
//        public async Task<ApplicationResponse<RegisterResponse>> Register([FromBody] RegisterRequest model)
//        {
//            return await _service.RegisterAccount(model);
//        }
//    }
//}
