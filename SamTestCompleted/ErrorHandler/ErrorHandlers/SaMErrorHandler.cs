using System;
using System.Threading.Tasks;

using ContractsLibrary.ErrorHandling;
using ContractsLibrary.Logging;
using ContractsLibrary.Mailing;

using ErrorHandler.Helpers;



namespace ErrorHandler.ErrorHandlers
{
    public class SaMErrorHandler : ISaMErrorHandler
    {
        private ILogService _isaMLogService;

        private IMailService _mailService;



        public SaMErrorHandler(ILogService isaMLogService, IMailService mailService)
        {
            _isaMLogService = isaMLogService;
            _mailService = mailService;
        }



        public void HandleUiError(ISaMUiError uiError)
        {
            _isaMLogService.LogWarning(uiError.Detail());
        }



        public async Task HandleUiErrorAsync(ISaMUiError uiError, DateTime when)
        {
            await _isaMLogService.LogWarningAsync(uiError.Detail(), when);
        }



        public void HandleError(Exception error)
        {
            throw new NotImplementedException();
        }



        public void HandleError(Exception error, string message = null)
        {
            _isaMLogService.LogError(message, error);
            _mailService.MailError(ErrorHelper.GetBeautifiedErrorMessage(error));
        }



        public void HandleError<TModel>(Exception error, TModel model)
        {
            throw new NotImplementedException();
        }



        public void HandleError<TModel>(Exception error, TModel model, string message)
        {
            throw new NotImplementedException();
        }



        public Task HandleErrorAsync(Exception error, DateTime when)
        {
            throw new NotImplementedException();
        }



        public async Task HandleErrorAsync(Exception error, DateTime when, string message = null)
        {
            await _isaMLogService.LogErrorAsync(message, when, error);
            await _mailService.MailErrorAsync(ErrorHelper.GetBeautifiedErrorMessage(error));
        }



        public Task HandleErrorAsync<TModel>(Exception error, DateTime when, TModel model)
        {
            throw new NotImplementedException();
        }



        public Task HandleErrorAsync<TModel>(Exception error, DateTime when, TModel model, string message)
        {
            throw new NotImplementedException();
        }



        public string BeautifyError(Exception error, DateTime when, string message = null)
        {
            var nl = Environment.NewLine;
            var msg = "";

            return msg;
        }

    }
}
