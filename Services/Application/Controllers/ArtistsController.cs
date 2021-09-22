using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VoicePlatform.Data.Application;
using VoicePlatform.Data.Entities;
using VoicePlatform.Data.Requests;
using VoicePlatform.Service.Interfaces;

namespace VoicePlatform.Application.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistService _service;

        public ArtistsController(IArtistService service)
        {
            _service = service;
        }

        // GET: ArtistsController
        [HttpGet]
        [Route("Artists/GetAllArtist")]
        public async Task<Response> GetAll(Pagination pagination)
        {
            return await _service.GetAllArtist(pagination);
        }

        [HttpPost]
        [Route("Artists/Register")]
        public async Task<Response> RegisterAnArtist([FromBody] ArtistRequest artist)
        {
            return await _service.RegisterAnArtist(artist);
        }

    }
}
