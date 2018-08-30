using System;





namespace SamProjectTelerik.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public string Content { get; set; }
        public DateTime DateTimeOfPosting { get; set; }
        public DateTime DateTimeOfModify { get; set; }
    }
}
