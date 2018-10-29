using System;
using System.Threading.Tasks;



namespace Logger.Interfaces
{





    public interface ILogger
    {
        Task LogInformationAsync(string message, DateTime when);
        Task LogWarningAsync(string message, DateTime when);
        Task LogErrorAsync(string message, DateTime when, Exception exception);
    }





}
