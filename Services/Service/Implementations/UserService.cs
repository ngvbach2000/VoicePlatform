using Entity.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Service.Interfaces;
using Utility.Settings;

#pragma warning disable

namespace Service.Implementations
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
