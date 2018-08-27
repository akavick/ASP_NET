namespace SamProject.Models
{





    public class Project
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public Client Client { get; set; } = new Client();
        public string Department { get; set; } = "";
        public string Market { get; set; } = "";
        public Person ProjectManager { get; set; } = new Person();
        public Person Smd { get; set; } = new Person();
    }





}
