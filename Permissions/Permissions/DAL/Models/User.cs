using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.DAL.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public ICollection<UserPermission> UserPermissions { get; set; }

    }
}
