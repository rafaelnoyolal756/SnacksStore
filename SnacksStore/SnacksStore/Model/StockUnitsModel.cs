using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnacksStore.Model
{
    public class StockUnitsModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int stockCount { get; set; }
        public DateTime date { get; set; }
    }
}
