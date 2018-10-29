using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace ErrorHandler.Interfaces
{

    public interface IErrorHandler
    {

        void HandleUiError(IUiError uiError);
        Task HandleUiErrorAsync(IUiError uiError, DateTime when);
        void HandleError(Exception error, string message = null);
        Task HandleErrorAsync(Exception error, DateTime when, string message = null);

    }

}
