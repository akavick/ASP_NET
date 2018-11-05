using Microsoft.AspNetCore.Authorization;



namespace Permissions.Authorization.Requirements
{

    public class ComponentCodeRequirement : IAuthorizationRequirement
    {
        public int ComponentCode { get; private set; }

        public ComponentCodeRequirement(int componentCode)
        {
            ComponentCode = componentCode;
        }
    }

}