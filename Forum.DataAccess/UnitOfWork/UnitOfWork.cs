using Forum.DataAccess.Data;
using Forum.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public IPersonRepository PersonRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            PersonRepository = new PersonRepository(context);
        }
    }
}
