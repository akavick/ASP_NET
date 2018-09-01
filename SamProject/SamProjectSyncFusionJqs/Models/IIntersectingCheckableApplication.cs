using System;





namespace SamProjectSyncFusionJqs.Models
{





    public interface IIntersectingCheckableApplication
    {
        DateTime BeginDate { get; set; }
        DateTime EndDate { get; set; }
        bool IntersectsWith(IIntersectingCheckableApplication application);
    }





}
