using System;

using Microsoft.AspNetCore.Html;




namespace SamProject.Models
{





    public class RsApplication : IIntersectingCheckableApplication
    {
        private DateTime _beginDate = new DateTime(DateTime.Now.Year, 1, 1);
        private DateTime _endDate = new DateTime(DateTime.Now.Year, 12, 31);





        public int Id { get; set; }
        public string Number { get; set; } = "0000";
        public RsApplicationStatus ApplicationStatus { get; set; } = new RsApplicationStatus();
        public Specialty Specialty { get; set; } = new Specialty();
        public Qualification Qualification { get; set; } = new Qualification();
        public Project Project { get; set; }
        public Person ProjectManager { get; set; }
        public Person Smd { get; set; }
        public Person Candidate { get; set; }
        public Rate Rate { get; set; } = new Rate();
        public string Department { get; set; }
        public string CandidateDescription { get; set; }

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

        public decimal Hours => ((EndDate - BeginDate).Days + 1) * 8 * Rate.Value;



        public string RsApplicationLink { get; set; }





        public bool IntersectsWith(IIntersectingCheckableApplication application)
        {
            return ReservationSystemHelper.ApplicationsIntersect(this, application);
        }

    }





}