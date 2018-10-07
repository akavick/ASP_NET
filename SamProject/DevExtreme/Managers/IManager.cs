using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DevExtreme.Models;

using Repository.Models;





namespace DevExtreme.Managers
{





    public interface IManager
    {
        Task<IEnumerable<ChartData<DateTime>>> GetColumnsDataAsync(RsApplication application);
        Task<IEnumerable<ChartData<DateTime>>> GetLineDataAsync(RsApplication application);
        Task<IEnumerable<RsApplication>> GetCrossingGridDataAsync(RsApplication application);
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task<IEnumerable<Person>> GetPeopleAsync();
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<IEnumerable<Rate>> GetRatesAsync();
        Task<IEnumerable<RsApplication>> GetApplicationsAsync();
        Task<IEnumerable<AmOzsApplication>> GetAmOzsApplicationsAsync(RsApplication application);
        Task<IEnumerable<AmRateApplication>> GetAmRateApplicationsAsync(RsApplication application);
        Task<RsApplication> GetNewApplication();
    }





}
