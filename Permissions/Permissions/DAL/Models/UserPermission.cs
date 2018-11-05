using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.DAL.Models
{
    public class UserPermission
    {
        public int UserId { get; set; }

        public User User { get; set; }
        public int PermissionId { get; set; }

        public Permission Permission { get; set; }

        public Guid ObjectId { get; set; }

    }
}
