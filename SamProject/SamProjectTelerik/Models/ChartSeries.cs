using System.Collections.Generic;





namespace SamProjectTelerik.Models
{





    public class ChartSeries<TX, TY>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public IEnumerable<ChartPoint<TX, TY>> DataSource { get; set; }
    }





}