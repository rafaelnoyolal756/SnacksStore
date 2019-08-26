using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnacksStore.Entities;

namespace SnacksStore.Repository
{
    public class LikingProductsRepository : GenericRepository<LikingProducts>, ILikingProductsRepository
    {
        public LikingProductsRepository(SnacksStoreDbContext dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
