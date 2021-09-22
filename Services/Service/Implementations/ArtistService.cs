using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VoicePlatform.Data;
using VoicePlatform.Data.Application;
using VoicePlatform.Data.Entities;
using VoicePlatform.Data.Repositories;
using VoicePlatform.Data.Requests;
using VoicePlatform.Data.Responses;
using VoicePlatform.Service.Interfaces;

namespace VoicePlatform.Service.Implementations
{
    public class ArtistService : BaseService, IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IGenderRepository _genderRepository;

        public ArtistService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _artistRepository = unitOfWork.Artist;
            _genderRepository = unitOfWork.Gender;
        }

        public async Task<Response> GetAllArtist(Pagination pagination)
        {
            var artists = await _artistRepository.GetAll().Select(x => new ArtistResponse
            {
                Id = x.Id,
                Username = x.Username,
                Email = x.Email,
                Phone = x.Phone,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Avatar = x.Avatar,
                Bio = x.Bio,
                Gender = x.Gender.Name,
                Price = x.Price,
                Status = x.Status,
                CreateDate = x.CreateDate,
            }).OrderBy(x => x.Price).Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();
            return Response.OK(artists);
        }

        public async Task<Response> RegisterAnArtist(ArtistRequest artist)
        {
            var id = Guid.NewGuid();
            var genderId = _genderRepository.GetMany(x => x.Name.Equals(artist.Gender)).Select(x => x.Id).FirstOrDefault(); ;
            if (IsUsernameExist(artist))
            {
                return Response.BadRequest("Username already exists.");
            }
            if (IsEmailExist(artist))
            {
                return Response.BadRequest("Email already exists.");
            }
            if (IsPhoneExist(artist))
            {
                return Response.BadRequest("Phone number already exists.");
            }
            if (genderId == Guid.Empty)
            {
                return Response.BadRequest("Your gender is not valid.");
            }
            var record = new Artist
            {
                Id = id,
                Username = artist.Username,
                Email = artist.Email,
                Phone = artist.Phone,
                Password = artist.Password,
                FirstName = artist.FirstName,
                LastName = artist.LastName,
                Avatar = "",
                Bio = "",
                Price = 0,
                GenderId = genderId,
                Status = "Activated",
                CreateDate = DateTime.Now,
            };
            try
            {
                _artistRepository.Add(record);
                await _unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                var message = e.Message;
                return Response.BadRequest(message);
            }
            return Response.OK();
        }

        private bool IsUsernameExist(ArtistRequest artist)
        {
            return _artistRepository.GetMany(x => x.Username.Equals(artist.Username)).ToList().Count > 0;
        }
        private bool IsEmailExist(ArtistRequest artist)
        {
            return _artistRepository.GetMany(x => x.Email.Equals(artist.Email)).ToList().Count > 0;
        }
        private bool IsPhoneExist(ArtistRequest artist)
        {
            return _artistRepository.GetMany(x => x.Phone.Equals(artist.Phone)).ToList().Count > 0;
        }
    }
}
