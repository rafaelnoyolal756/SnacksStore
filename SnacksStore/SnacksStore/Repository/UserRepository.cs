using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnacksStore.Entities;

namespace SnacksStore.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SnacksStoreDbContext dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
