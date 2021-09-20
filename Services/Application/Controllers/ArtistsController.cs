using Data.Application;
using Data.Requests.Artist;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class ArtistsController : Controller
    {
        private IArtistService _service;

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
