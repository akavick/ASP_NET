using System.Collections.Generic;



namespace Permissions.DAL.FakeRepository
{



    public class Role
    {
        public int RoleId { get; set; }

        public string Title { get; set; }

        public List<Permission> Permissions { get; set; } = new List<Permission>();
    }



}