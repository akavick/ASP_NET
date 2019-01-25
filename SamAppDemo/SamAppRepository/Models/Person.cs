namespace SamAppRepository.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PatronymicName { get; set; }

        public Specialty Specialty { get; set; } = new Specialty();

        public Qualification Qualification { get; set; } = new Qualification();

        public string FullName => Id == 0 ? string.Empty : $"{LastName} {FirstName} {PatronymicName}";

        public string FullInfo => Id == 0 ? string.Empty : $"{LastName} {FirstName} {PatronymicName}, {Qualification} {Specialty}";
    }
}