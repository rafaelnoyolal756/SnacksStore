using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SnacksStore.Entities
{
    [Table("LikingProducts", Schema = "dbo")]
    public class LikingProducts : BaseEntity
    {
        [Key]
        public int LikingProductsId { get; set; }
        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        
        public virtual ICollection<Product> LikingProductsProducts { get; set; }

        
        public virtual ICollection<User> LikingProductsUsers { get; set; }
    }
}
