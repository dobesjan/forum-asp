using Forum.DataAccess.Data;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) : base(context) { }

        public Person GetPerson(string userId)
        {
            return Get(p => p.UserId == userId);
        }
    }
}
