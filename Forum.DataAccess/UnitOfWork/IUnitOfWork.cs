using Forum.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPersonRepository PersonRepository { get; }
    }
}
