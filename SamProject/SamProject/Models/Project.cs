namespace SamProject.Models
{





    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Client Client { get; set; }
        public string Department { get; set; }
        public string Market { get; set; } = "";
        public Person ProjectManager { get; set; }
        public Person Smd { get; set; }
    }





}
