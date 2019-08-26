using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SnacksStore.Entities
{
    [Table("StockUnits", Schema = "dbo")]
    public class StockUnits : BaseEntity
    {
        [Key]
        public int StockUnitsId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        
        public int stockCount { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        public StockUnits()
        {
            StockUnitsProducts = new List<Product>();
        }
        public virtual ICollection<Product> StockUnitsProducts { get; set; }
    }
}
