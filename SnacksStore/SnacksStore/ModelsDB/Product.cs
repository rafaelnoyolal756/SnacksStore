﻿using System;
using System.Collections.Generic;

namespace SnacksStore.ModelsDB
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Size { get; set; }
    }
}
