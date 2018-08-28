using System;





namespace SamProject.Models
{





    public class RsApplication : IIntersectingCheckableApplication
    {
        private DateTime _beginDate = new DateTime(DateTime.Now.Year, 1, 1);
        private DateTime _endDate = new DateTime(DateTime.Now.Year, 12, 31);





        public int Id { get; set; } = 0;
        public string Number { get; set; } = "0000";
        public RsApplicationStatus ApplicationStatus { get; set; } = new RsApplicationStatus();
        public Specialty Specialty { get; set; } = new Specialty();
        public Qualification Qualification { get; set; } = new Qualification();
        public Project Project { get; set; } = new Project();
        public Person ProjectManager { get; set; } = new Person();
        public Person Smd { get; set; } = new Person();
        public Person Candidate { get; set; } = new Person();
        public decimal Rate { get; set; } = 0.0m;
        public string Department { get; set; } = "";
        public string Market { get; set; } = "";
        public string CandidateDescription { get; set; } = "";

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