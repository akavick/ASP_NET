using System;
using System.Threading.Tasks;

using ContractsLibrary.ErrorHandling;

using ErrorHandler.Helpers;

using Logger.Interfaces;

using Mailer.Interfaces;



namespace ErrorHandler.ErrorHandlers
{
    public class ErrorHandler : IErrorHandler
    {
        private ILogProcessor _logProcessor;

        private IMailProcessor _mailProcessor;



        public ErrorHandler(ILogProcessor logProcessor, IMailProcessor mailProcessor)
        {
            _logProcessor = logProcessor;
            _mailProcessor = mailProcessor;
        }



        public void HandleUiError(IUiError uiError)
        {
            _logProcessor.LogWarning(uiError.ToMsgString());
        }



        public async Task HandleUiErrorAsync(IUiError uiError, DateTime when)
        {
            await _logProcessor.LogWarningAsync(uiError.ToMsgString(), when);
        }



        public void HandleError(Exception error, string message = null)
        {
            _logProcessor.LogError(message, error);
            _mailProcessor.MailError(ErrorHelper.GetBeautifiedErrorMessage(error));
        }



        public async Task HandleErrorAsync(Exception error, DateTime when, string message = null)
        {
            await _logProcessor.LogErrorAsync(message, when, error);
            await _mailProcessor.MailErrorAsync(ErrorHelper.GetBeautifiedErrorMessage(error));
        }



        public string BeautifyError(Exception error, DateTime when, string message = null)
        {
            var nl = Environment.NewLine;
            var msg = "";

            return msg;
        }

    }
}
