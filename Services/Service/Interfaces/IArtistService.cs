using Data.Application;
using Data.Requests.Artist;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IArtistService
    {
        Task<Response> GetAllArtist(Pagination pagination);
        Task<Response> RegisterAnArtist(ArtistRequest artist);
    }
}
