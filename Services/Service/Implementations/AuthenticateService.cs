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
    public class AuthenticateService : BaseService, IAuthenticateService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly AppSettings _appSettings;

        public AuthenticateService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings) : base(unitOfWork)
        {
            _appSettings = appSettings.Value;
            _artistRepository = unitOfWork.Artist;
            _customerRepository = unitOfWork.Customer;
        }

        public async Task<Response> Authenticate(AuthenticateRequest authenticate)
        {
            var customer = _customerRepository.GetMany(x => x.Username.Equals(authenticate.Username)
                && x.Password.Equals(authenticate.Password));
            if (customer.Count() == 0)
            {
                var artist = _artistRepository.GetMany(x => x.Username.Equals(authenticate.Username)
                && x.Password.Equals(authenticate.Password));
                if (artist.Count() > 0)
                {
                    var token = generateJwtToken(await artist.Select(x => new Authenticate
                    {
                        Id = x.Id,
                        Username = x.Username,
                        Role = x.Role.ToString(),
                        Status = x.Status
                    }).FirstOrDefaultAsync());

                    return Response.OK(await artist.Select(x => new AuthenticateResponse
                    {
                        Id = x.Id,
                        Username = x.Username,
                        Email = x.Email,
                        Phone = x.Phone,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        AvatarUrl = x.Avatar,
                        Bio = x.Bio,
                        Gender = x.Gender.Name,
                        Role = x.Role.ToString(),
                        Status = x.Status,
                        Token = token
                    }).FirstOrDefaultAsync());
                }
                else
                {
                    return Response.NotFound("Username or password is incorrect");
                }
            }
            else
            {
                var token = generateJwtToken(await customer.Select(x => new Authenticate
                {
                    Id = x.Id,
                    Username = x.Username,
                    Role = x.Role.ToString(),
                    Status = x.Status
                }).FirstOrDefaultAsync());
                return Response.OK(await customer.Select(x => new AuthenticateResponse
                {
                    Id = x.Id,
                    Username = x.Username,
                    Email = x.Email,
                    Phone = x.Phone,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    AvatarUrl = x.Avatar,
                    Bio = x.Bio,
                    Gender = x.Gender.Name,
                    Role = x.Role.ToString(),
                    Status = x.Status,
                    Token = token
                }).FirstOrDefaultAsync());
            }
        }

        public async Task<Authenticate> GetUserById(Guid Id)
        {
            var cus = _customerRepository.FirstOrDefault(x => x.Id == Id);
            if (cus != null)
            {
                return new Authenticate
                {
                    Id = cus.Id,
                    Username = cus.Username,
                    Role = cus.Role.ToString(),
                    Status = cus.Status
                };
            }

            var artis = _artistRepository.FirstOrDefault(x => x.Id == Id);
            if (artis != null)
            {
                return new Authenticate
                {
                    Id = artis.Id,
                    Username = artis.Username,
                    Role = artis.Role.ToString(),
                    Status = artis.Status
                };
            }

            return null;
            //var customer = _customerRepository.GetMany(x => x.Id.Equals(Id));
            //if (customer.Count() > 0)
            //{
            //    return await customer.Select(x => new Authenticate
            //    {
            //        Id = x.Id,
            //        Username = x.Username,
            //        Role = x.Role.ToString(),
            //        Status = x.Status
            //    }).FirstOrDefaultAsync();
            //}
            //else
            //{
            //    return await _artistRepository.GetMany(x => x.Id.Equals(Id)).Select(x => new Authenticate
            //    {
            //        Id = x.Id,
            //        Username = x.Username,
            //        Role = x.Role.ToString(),
            //        Status = x.Status
            //    }).FirstOrDefaultAsync();
            //}
        }

        private string generateJwtToken(Authenticate user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var id = user.Id.ToString();
            var role = user.Role;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim("role", user.Role) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
