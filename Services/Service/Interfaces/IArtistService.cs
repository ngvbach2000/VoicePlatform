using System.Threading.Tasks;
using VoicePlatform.Data.Application;
using VoicePlatform.Data.Entities;
using VoicePlatform.Data.Requests;

namespace VoicePlatform.Service.Interfaces
{
    public interface IArtistService
    {
        Task<Response> GetAllArtist(Pagination pagination);
        Task<Response> RegisterAnArtist(ArtistRequest artist);
    }
}
