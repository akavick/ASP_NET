using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;





namespace SamProject.Models
{





    public abstract class AmApplication
    {
        public int Id { get; set; } = 0;
        public string Number { get; set; } = "00-000000";
        public DateTime BeginDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        public Person Person { get; set; } = new Person();
    }





}
