using System.Collections.Generic;

using Repository.Models;





namespace Repository.Repositories
{

    public interface IRepository
    {
        IEnumerable<Comment> Comments { get; }
        IEnumerable<Person> People { get; }
        IEnumerable<Client> Clients { get; }
        IEnumerable<Project> Projects { get; }
        IEnumerable<RsApplication> ReservationSystemApplications { get; }
        IEnumerable<AmApplication> AmApplications { get; }
    }

}
