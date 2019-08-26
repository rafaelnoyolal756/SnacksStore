using System;
using System.Collections.Generic;

namespace SnacksStore.ModelsDB
{
    public partial class LikingProducts
    {
        public int LikingProductsId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
