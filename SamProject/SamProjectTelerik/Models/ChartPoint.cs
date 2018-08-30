namespace SamProjectTelerik.Models
{





    public class ChartPoint<TX, TY>
    {
        public int Id { get; set; }
        public object Data { get; set; }
        public TX X { get; set; }
        public TY Y { get; set; }
    }





}