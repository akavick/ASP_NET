using System;
using System.Threading.Tasks;



namespace ContractsLibrary.ErrorHandling
{

    public interface IErrorHandler
    {

        void HandleUiError(IUiError uiError);
        Task HandleUiErrorAsync(IUiError uiError, DateTime when);
        void HandleError(Exception error, string message = null);
        Task HandleErrorAsync(Exception error, DateTime when, string message = null);

    }

}
