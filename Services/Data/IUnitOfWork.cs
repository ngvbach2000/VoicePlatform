using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoicePlatform.Data.Repositories;

namespace VoicePlatform.Data
{
    public interface IUnitOfWork
    {
        public IArtistRepository Artist { get; }
        public ICustomerRepository Customer { get; }

        public IGenderRepository Gender { get; }

        Task<int> SaveChanges();
    }
}
