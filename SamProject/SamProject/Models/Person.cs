namespace SamProject.Models
{





    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public Specialty Specialty { get; set; }
        public Qualification Qualification { get; set; }
        public string Fullname => $"{LastName} {FirstName} {PatronymicName}";
        public string FullInfo => $"{LastName} {FirstName} {PatronymicName}, {Qualification.String()} {Specialty.String()}";
    }





}