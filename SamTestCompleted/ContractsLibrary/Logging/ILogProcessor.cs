using System;
using System.Threading.Tasks;



namespace ContractsLibrary.Logging
{





    public interface ILogProcessor
    {
        void Subscribe(ILogger logger);
        void Unsubscribe(ILogger logger);
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message, Exception exception);
        Task LogInformationAsync(string message, DateTime when);
        Task LogWarningAsync(string message, DateTime when);
        Task LogErrorAsync(string message, DateTime when, Exception exception);
    }





}
