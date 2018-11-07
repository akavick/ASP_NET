using System.Collections.Generic;



namespace Permissions.DAL.Repository.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public ICollection<UserPermission> UserPermissions { get; set; }

    }
}
