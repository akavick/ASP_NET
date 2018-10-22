using System;
using System.Threading.Tasks;





namespace SamLogger.Interfaces
{





    public interface ISamLogProcessor
    {
        void Subscribe(ISamLogger logger);
        void Unsubscribe(ISamLogger logger);
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message, Exception exception);
        Task LogInformationAsync(string message, DateTime when);
        Task LogWarningAsync(string message, DateTime when);
        Task LogErrorAsync(string message, DateTime when, Exception exception);
    }





}
