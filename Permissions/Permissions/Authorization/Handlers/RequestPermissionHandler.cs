using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

using Permissions.Authorization.Requirements;
using Permissions.DAL.FakeRepository;



namespace Permissions.Authorization.Handlers
{



    public class RequestPermissionHandler : AuthorizationHandler<OperationAuthorizationRequirement, Request>
    {
        private readonly Repository _repository;



        public RequestPermissionHandler(Repository repository)
        {
            _repository = repository;
        }



        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Request request)
        {
            var permissionId = _repository.Permissions
                                          .SingleOrDefault(p => p.Title == requirement.Name)?.PermissionId;

            if (permissionId.HasValue && context.User.HasClaim(request.RequestId.ToString(), permissionId.Value.ToString()))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }



}