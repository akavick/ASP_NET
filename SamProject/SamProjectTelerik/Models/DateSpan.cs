using System;





namespace SamProjectTelerik.Models
{





    public class DateSpan : IIntersectingCheckableApplication
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }





        public bool IntersectsWith(IIntersectingCheckableApplication application)
        {
            return ReservationSystemHelper.ApplicationsIntersect(this, application);
        }
    }





}