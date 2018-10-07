using System.Collections.Generic;





namespace DevExtreme.Models
{





    public class ChartData<T>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public IEnumerable<ChartPoint<T>> DataSource { get; set; }
        //public Syncfusion.EJ2.Charts.ChartSeriesType SeriesType { get; set; }
    }





}