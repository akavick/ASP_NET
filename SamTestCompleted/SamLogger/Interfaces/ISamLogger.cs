using System;
using System.Threading.Tasks;





namespace SamLogger.Interfaces
{





    public interface ISamLogger
    {
        Task LogInformation(string message);
        Task LogWarning(string message);
        Task LogError(string message, Exception exception);
    }





}
