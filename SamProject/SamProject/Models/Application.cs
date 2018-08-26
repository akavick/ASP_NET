using System;

using Microsoft.AspNetCore.Mvc.ModelBinding;





namespace SamProject.Models
{





    public class Application
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public Specialty Specialty { get; set; }
        public Qualification Qualification { get; set; }
        public Project Project { get; set; }
        public Person ProjectManager { get; set; }
        public Person Smd { get; set; }
        public Person Candidate { get; set; }
        public decimal Rate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Department { get; set; }
        public string Market { get; set; }


        public string ApplicationStatusString => ApplicationStatus.String();

        public string SpecialtyString => Specialty.String();

        public string QualificationString => Qualification.String();
    }





}