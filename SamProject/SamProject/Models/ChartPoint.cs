namespace SamProject.Models
{





    public class ChartPoint<T>
    {
        private static int _idCounter = 0;




        public int Id { get; } = ++_idCounter;
        public T X { get; set; }
        public double Y { get; set; }
        public int RsApplicationId { get; set; }
        public string RsApplicationNumber { get; set; }
    }





}