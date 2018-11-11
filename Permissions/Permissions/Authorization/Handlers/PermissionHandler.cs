using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

using Permissions.Authorization.Requirements;
using Permissions.DAL.FakeRepository;



namespace Permissions.Authorization.Handlers
{

    public class PermissionHandler : IAuthorizationHandler
    {
        private Repository _repository;



        public PermissionHandler(Repository repository)
        {
            _repository = repository;
        }



        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();

            foreach (var requirement in pendingRequirements)
            {
                if (requirement is ComponentCodeRequirement)
                {
                    if (IsOwner(context.User, context.Resource) || IsSponsor(context.User, context.Resource))
                    {
                        context.Succeed(requirement);
                    }
                }

                //if (requirement is ReadPermission)
                //{
                //    if (IsOwner(context.User, context.Resource) || IsSponsor(context.User, context.Resource))
                //    {
                //        context.Succeed(requirement);
                //    }
                //}
                //else if (requirement is EditPermission || requirement is DeletePermission)
                //{
                //    if (IsOwner(context.User, context.Resource))
                //    {
                //        context.Succeed(requirement);
                //    }
                //}
            }

            //todo
            return Task.CompletedTask;
        }



        private bool IsOwner(ClaimsPrincipal user, object resource)
        {
            // Code omitted for brevity

            return true;
        }



        private bool IsSponsor(ClaimsPrincipal user, object resource)
        {
            // Code omitted for brevity

            return true;
        }

    }

}