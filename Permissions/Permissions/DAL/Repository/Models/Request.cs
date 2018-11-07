namespace Permissions.DAL.Repository.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }

    }
}
