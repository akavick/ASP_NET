using System.Threading.Tasks;

using ContractsLibrary.Mailing;



namespace Mailer.MailProcessors
{

    public class MailProcessor : IMailProcessor
    {

        public void MailError(string errorMsg)
        {
            
        }



        public Task MailErrorAsync(string errorMsg)
        {
            return Task.CompletedTask;
        }
    }

}