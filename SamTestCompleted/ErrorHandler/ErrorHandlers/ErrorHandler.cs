using System;
using System.Threading.Tasks;

using ErrorHandler.Interfaces;



namespace ErrorHandler.ErrorHandlers
{
    public class ErrorHandler : IErrorHandler
    {
        public ErrorHandler()
        {
            
        }



        public void HandleUiError(IUiError uiError, string message = null)
        {
            
        }



        public Task HandleUiErrorAsync(IUiError uiError, DateTime when, string message = null)
        {
            throw new NotImplementedException();
        }



        public void HandleError(Exception error, string message = null)
        {
            
        }



        public Task HandleErrorAsync(Exception error, DateTime when, string message = null)
        {
            throw new NotImplementedException();
        }
    }
}
