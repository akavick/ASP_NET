﻿using System.Collections.Generic;

using SamProjectTelerik.Models;





namespace SamProjectTelerik.Repositories
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
