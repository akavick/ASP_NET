namespace Permissions.DAL.FakeRepository
{



    public class Request
    {
        public int RequestId { get; set; }

        public Principal Author { get; set; }

        public string Status { get; set; }
    }
}
