using System.Threading.Tasks;

using Mailer.Interfaces;



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