using System.Collections.Generic;





namespace SamProject.Models
{





    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public Dictionary<Specialty, Qualification> Specialties { get; set; }
        public Specialty Specialty { get; set; }
        public string SpecialtyString => Specialty.String();
        public Qualification Qualification { get; set; }
        public string QualificationString => Qualification.String();
        public string FullName => $"{LastName} {FirstName} {PatronymicName}";
        public string FullInfo => $"{LastName} {FirstName} {PatronymicName}, {Qualification.String()} {Specialty.String()}";
    }





}