using Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public interface IUnitOfWork
    {
        public IArtistRepository Artist { get; }
        public IGenderRepository Gender { get; }

        Task<int> SaveChanges();
    }
}
