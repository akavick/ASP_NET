using System.Threading.Tasks;



namespace Mailer.Interfaces
{

    public interface IMailProcessor
    {
        void MailError(string errorMsg);
        Task MailErrorAsync(string errorMsg);
    }

}