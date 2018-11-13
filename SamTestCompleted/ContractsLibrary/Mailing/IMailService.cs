using System.Threading.Tasks;



namespace ContractsLibrary.Mailing
{

    public interface IMailService
    {
        void MailError(string errorMsg);
        Task MailErrorAsync(string errorMsg);
    }

}