using System;





namespace SamProjectTelerik.Models
{





    public static class ReservationSystemHelper
    {
        public static bool ApplicationsIntersect(IIntersectingCheckableApplication app1, IIntersectingCheckableApplication app2)
        {
            if (app1 is null)
            {
                throw new ArgumentNullException(nameof(app1));
            }

            if (app2 is null)
            {
                throw new ArgumentNullException(nameof(app2));
            }

            var result =
                app1.BeginDate >= app2.BeginDate
                && app1.BeginDate <= app2.EndDate
                ||
                app2.BeginDate >= app1.BeginDate
                && app2.BeginDate <= app1.EndDate;

            return result;
        }

    }

}