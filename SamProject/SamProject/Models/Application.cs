using System;





namespace SamProject.Models
{





    public class Application
    {
        public int Id { get; set; } = 0;
        public string Number { get; set; } = "0000";
        public ApplicationStatus ApplicationStatus { get; set; } = new ApplicationStatus();
        public Specialty Specialty { get; set; } = new Specialty();
        public Qualification Qualification { get; set; } = new Qualification();
        public Project Project { get; set; } = new Project();
        public Person ProjectManager { get; set; } = new Person();
        public Person Smd { get; set; } = new Person();
        public Person Candidate { get; set; } = new Person();
        public decimal Rate { get; set; } = 0.0m;
        public DateTime BeginDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        public string Department { get; set; } = "";
        public string Market { get; set; } = "";
        public string CandidateDescription { get; set; } = "";
    }





}