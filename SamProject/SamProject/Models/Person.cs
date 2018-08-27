using System.Collections.Generic;





namespace SamProject.Models
{





    public class Person
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string PatronymicName { get; set; } = "";
        public Specialty Specialty { get; set; } = Specialty.Developer;
        public string SpecialtyString => Id == 0 ? "" : Specialty.SamString();
        public Qualification Qualification { get; set; } = Qualification.Junior;
        public string QualificationString => Id == 0 ? "" : Qualification.SamString();
        public string FullName => Id == 0 ? "" : $"{LastName} {FirstName} {PatronymicName}";
        public string FullInfo => Id == 0 ? "" : $"{LastName} {FirstName} {PatronymicName}, {Qualification.SamString()} {Specialty.SamString()}";

        //public Dictionary<Specialty, Qualification> Specialties { get; set; } // todo
    }





}