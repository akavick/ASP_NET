using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.DAL.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }

    }
}
