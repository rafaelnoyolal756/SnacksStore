using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnacksStore.Model
{
    public class StockUnitsListModel
    {
        public IEnumerable<StockUnitsModel> StockUnits { get; set; }
    }
}
