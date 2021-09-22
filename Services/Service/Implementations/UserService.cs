using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using VoicePlatform.Data.Contexts;
using VoicePlatform.Service.Interfaces;
using VoicePlatform.Utility.Settings;

#pragma warning disable

namespace VoicePlatform.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        private readonly AppSettings _appSettings;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IOptions<AppSettings> appSettings, AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
