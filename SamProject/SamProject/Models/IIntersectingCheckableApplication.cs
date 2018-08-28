using System;





namespace SamProject.Models
{





    public interface IIntersectingCheckableApplication
    {
        DateTime BeginDate { get; set; }
        DateTime EndDate { get; set; }
        bool IntersectsWith(IIntersectingCheckableApplication application);
    }





}
