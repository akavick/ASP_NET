using System.Security.Principal;
using System.Threading.Tasks;



namespace ContractsLibrary.Authorization
{

    public interface IAuthorizer
    {
        bool TryAuthorize(IPrincipal user, string resourceId, string permission);

        Task<bool> TryAuthorizeAsync(IPrincipal user, string resourceId, string permission);
    }

}