using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamProject.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Client Client { get; set; }
    }





    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
