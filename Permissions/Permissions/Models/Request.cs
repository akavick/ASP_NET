using System;

namespace Permissions.Models
{



    public class Request : IUnit
    {
        public int RequestId { get; set; }

        public int AuthorId { get; set; }

        public Principal Author { get; set; }

        public string Status { get; set; }

        public int UnitId { get; set; }
    }
}
