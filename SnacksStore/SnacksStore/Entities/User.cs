using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SnacksStore.Entities
{
    [Table("User", Schema = "dbo")]
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public User()
        {
            UserProducts = new List<Product>();
        }
        public virtual ICollection <Product> UserProducts { get; set; }
    }
}
