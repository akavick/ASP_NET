using System.Security.Principal;
using System.Threading.Tasks;

using ContractsLibrary.Authorization;



namespace AuthorizationLogic
{

    public class AuthorizationService : IAuthorizationService
    {

        public bool TryAuthorize(IPrincipal user, string resourceId, string permission)
        {
            return true;
        }



        public async Task<bool> TryAuthorizeAsync(IPrincipal user, string resourceId, string permission)
        {
            return await Task.FromResult(true);
        }
    }

}