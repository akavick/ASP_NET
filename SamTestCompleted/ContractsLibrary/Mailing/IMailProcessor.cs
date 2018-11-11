using System.Threading.Tasks;



namespace ContractsLibrary.Mailing
{

    public interface IMailProcessor
    {
        void MailError(string errorMsg);
        Task MailErrorAsync(string errorMsg);
    }

}