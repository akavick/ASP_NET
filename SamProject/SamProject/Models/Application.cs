﻿using System;





namespace SamProject.Models
{





    public class Application
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public string ApplicationStatusString => ApplicationStatus.String();
        public Specialty Specialty { get; set; }
        public string SpecialtyString => Specialty.String();
        public Qualification Qualification { get; set; }
        public string QualificationString => Qualification.String();
        public Project Project { get; set; }
        public Person ProjectManager { get; set; }
        public Person Smd { get; set; }
        public Person Candidate { get; set; }
        public decimal Rate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Department { get; set; }
        public string Market { get; set; }
    }





}