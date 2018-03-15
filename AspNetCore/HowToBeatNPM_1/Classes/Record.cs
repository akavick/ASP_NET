﻿using System;
using System.Collections.Generic;

namespace HowToBeatNPM_1.Classes
{
    public class Record
    {
        public int RecordId { get; set; }
        public int OrderId { get; set; }
        public List<Customer> Customers { get; set; }
        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipCountry { get; set; }
    }
}