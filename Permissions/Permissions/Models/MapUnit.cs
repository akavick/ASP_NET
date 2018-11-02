using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Models
{
    public class MapUnit
    {
        public int MapUnitId { get; set; }

        public int PrincipalId { get; set; }

        public int PermissionId { get; set; }

        public int ObjectId { get; set; }
    }
}
