using System;



namespace Permissions.DAL.Repository.Models
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
