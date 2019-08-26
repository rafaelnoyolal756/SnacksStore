using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SnacksStore.Entities
{
    [Table("Product", Schema = "dbo")]
    public class Product : BaseEntity
    {

        [Key]
        public int ProductId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(260)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [MaxLength(100)]
        public string Size { get; set; }

        public Product()
        {
            ProductsLikingProducts = new List<LikingProducts>();
           
        }
        public virtual ICollection<LikingProducts> ProductsLikingProducts { get; set; }
        public object StockUnitsId { get; internal set; }
        public object UserId { get; internal set; }
        public int LikingProductsId { get; set; }
    }
}
