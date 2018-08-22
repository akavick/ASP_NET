using System;





namespace SamProject.Models
{





    public class ChartData<T>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public ChartPoint<T>[] DataSource { get; set; }
    }





}