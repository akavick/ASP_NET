using System.Collections.Generic;

using SamProject.Models;





namespace SamProject.Repositories
{

    public interface IRepository
    {
        IEnumerable<Comment> Comments { get; }
        IEnumerable<Person> People { get; }
        IEnumerable<Client> Clients { get; }
        IEnumerable<Project> Projects { get; }
        IEnumerable<decimal> Rates { get; }
        IEnumerable<RsApplication> ReservationSystemApplications { get; }
        IEnumerable<AmApplication> AmApplications { get; }
    }

}
