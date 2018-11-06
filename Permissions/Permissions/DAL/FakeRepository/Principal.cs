using System.Collections.Generic;



namespace Permissions.DAL.FakeRepository
{
    public class Principal
    {
        public int PrincipalId { get; set; }

        public string Name { get; set; }

        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
