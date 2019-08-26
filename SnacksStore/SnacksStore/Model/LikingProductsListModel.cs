using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnacksStore.Model
{
    public class LikingProductsListModel
    {
        public IEnumerable<LikingProductsModel> LikingProducts { get; set; }
    }
}
