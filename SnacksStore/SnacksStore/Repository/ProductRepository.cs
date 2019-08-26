using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnacksStore.Entities;

namespace SnacksStore.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SnacksStoreDbContext dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
