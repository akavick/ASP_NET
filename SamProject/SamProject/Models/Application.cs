using System;





namespace SamProject.Models
{





    public class Application
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public string ApplicationStatusString => ApplicationStatus.String();
        public Specialty Specialty { get; set; }
        public string SpecialtyString { get; set; }
        public Qualification Qualification { get; set; }
        public string QualificationString { get; set; }
        public Project Project { get; set; }
        public Person ProjectManager { get; set; }
        public Person Smd { get; set; }
        public Person Candidate { get; set; }
        public decimal Rate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }





}