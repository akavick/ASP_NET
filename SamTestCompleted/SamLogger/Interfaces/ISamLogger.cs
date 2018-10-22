using System;
using System.Threading.Tasks;





namespace SamLogger.Interfaces
{





    public interface ISamLogger
    {
        Task LogInformationAsync(string message, DateTime when);
        Task LogWarningAsync(string message, DateTime when);
        Task LogErrorAsync(string message, DateTime when, Exception exception);
    }





}
