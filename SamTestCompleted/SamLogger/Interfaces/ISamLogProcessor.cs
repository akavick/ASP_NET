using System;
using System.Threading.Tasks;





namespace SamLogger.Interfaces
{





    public interface ISamLogProcessor
    {
        void Subscribe(ISamLogger logger);
        void Unsubscribe(ISamLogger logger);
        Task LogInformation(string message);
        Task LogWarning(string message);
        Task LogError(string message, Exception exception);
    }





}
