using Entity.Contexts;
using Entity.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Entity
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private IArtistRepository _artist;
        private IGenderRepository _gender;


        public UnitOfWork(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public IArtistRepository Artist
        {
            get { return _artist ??= new ArtistRepository(_context); }
        }

        public IGenderRepository Gender
        {
            get { return _gender ??= new GenderRepository(_context); }
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
