using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnacksStore.Entities;

namespace SnacksStore.Repository
{
    public class StockUnitsRepository : GenericRepository<StockUnits>, IStockUnitsRepository
    {
        public StockUnitsRepository(SnacksStoreDbContext dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
