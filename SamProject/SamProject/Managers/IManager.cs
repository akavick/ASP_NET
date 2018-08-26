using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SamProject.Models;





namespace SamProject.Managers
{
    public interface IManager
    {
        Task<IEnumerable<ChartData<DateTime>>> GetColumnsDataAsync(Application application);
        Task<IEnumerable<ChartData<double>>> GetLineDataAsync(Application application);
        Task<IEnumerable<Application>> GetCrossingGridDataAsync(Application app);
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task<IEnumerable<Person>> GetPeopleAsync();
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<IEnumerable<decimal>> GetRatesAsync();
        Task<IEnumerable<Application>> GetApplicationsAsync();
    }
}
