using System;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

using Permissions.Authorization.Requirements;
using Permissions.DAL;
using Permissions.DAL.FakeRepository;



namespace Permissions.Authorization.Handlers
{



    public class TestHandler : AuthorizationHandler<TestRequirement>
    {
        private Repository _repository;



        public TestHandler(Repository repository)
        {
            _repository = repository;
        }



        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TestRequirement requirement)
        {
            //todo

            return Task.CompletedTask;
        }
    }



}