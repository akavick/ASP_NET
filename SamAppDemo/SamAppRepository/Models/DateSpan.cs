using System;

namespace SamAppRepository.Models
{
    public class DateSpan : IIntersectingCheckableApplication
    {
        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string BeginDateString => ReservationSystemHelper.GetFormattedDateString(BeginDate);

        public string EndDateString => ReservationSystemHelper.GetFormattedDateString(EndDate);

        public bool IntersectsWith(IIntersectingCheckableApplication application)
        {
            return ReservationSystemHelper.ApplicationsIntersect(this, application);
        }
    }
}