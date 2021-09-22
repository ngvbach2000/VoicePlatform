using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using VoicePlatform.Data.Contexts;
using VoicePlatform.Data.Repositories;

namespace VoicePlatform.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        private IArtistRepository _artist;
        private ICustomerRepository _customer;
        private IGenderRepository _gender;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IArtistRepository Artist
        {
            get { return _artist ??= new ArtistRepository(_context); }
        }
        public ICustomerRepository Customer
        {
            get { return _customer ??= new CustomerRepository(_context); }
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
