using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SnacksStore.Entities
{
    [Table("Role", Schema = "dbo")]
    public static class Role
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
