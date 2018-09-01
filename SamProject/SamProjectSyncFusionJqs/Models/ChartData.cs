using System.Collections.Generic;





namespace SamProjectSyncFusionJqs.Models
{





    public class ChartData<T>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public IEnumerable<ChartPoint<T>> DataSource { get; set; }
    }





}