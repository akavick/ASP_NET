using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Classes
{
    public class Record
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public List<Customer> Customers { get; set; }
        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipCountry { get; set; }
    }
}
