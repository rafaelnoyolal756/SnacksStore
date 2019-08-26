using System;
using System.Collections.Generic;

namespace SnacksStore.ModelsDB
{
    public partial class StockUnits
    {
        public int StockUnitsId { get; set; }
        public int ProductId { get; set; }
        public int? StockCount { get; set; }
        public DateTime? Date { get; set; }
    }
}
