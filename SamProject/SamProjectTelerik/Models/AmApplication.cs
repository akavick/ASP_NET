using System;





namespace SamProjectTelerik.Models
{





    public abstract class AmApplication : IIntersectingCheckableApplication
    {
        private DateTime _endDate = new DateTime(DateTime.Now.Year, 12, 31);
        private DateTime _beginDate = new DateTime(DateTime.Now.Year, 1, 1);





        public Person Person { get; set; }
        public int Id { get; set; }
        public string Number { get; set; } = "00-000000";

        public DateTime BeginDate
        {
            get => _beginDate;
            set => _beginDate = value.Date;
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => _endDate = value.Date;
        }
       




        public bool IntersectsWith(IIntersectingCheckableApplication application)
        {
            return ReservationSystemHelper.ApplicationsIntersect(this, application);
        }

    }





}
