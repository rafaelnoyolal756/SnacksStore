using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnacksStore.Model
{
    public class UserListModel
    {
        public IEnumerable<UserModel> Users { get; set; }
    }
}
