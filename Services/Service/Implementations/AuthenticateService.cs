using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VoicePlatform.Data;
using VoicePlatform.Data.Application;
using VoicePlatform.Data.Repositories;
using VoicePlatform.Data.Requests;
using VoicePlatform.Data.Responses;
using VoicePlatform.Service.Interfaces;
using VoicePlatform.Utility.Settings;

namespace VoicePlatform.Service.Implementations
{
    public class AuthenticateService : IAuthenticateService
    {
       
    }
}
