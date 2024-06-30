using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DataAccess.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person GetPerson(string userId);
    }
}
