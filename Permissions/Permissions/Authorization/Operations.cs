using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization.Infrastructure;



namespace Permissions.Authorization
{



    public static class Operations
    {
        public static OperationAuthorizationRequirement ViewRequest = new OperationAuthorizationRequirement {Name = nameof(ViewRequest)};

        public static OperationAuthorizationRequirement EditRequest = new OperationAuthorizationRequirement {Name = nameof(EditRequest)};

        public static OperationAuthorizationRequirement ApproveRequest = new OperationAuthorizationRequirement {Name = nameof(ApproveRequest)};

        public static OperationAuthorizationRequirement RejectRequest = new OperationAuthorizationRequirement {Name = nameof(RejectRequest)};

        public static OperationAuthorizationRequirement CreateRequest = new OperationAuthorizationRequirement {Name = nameof(CreateRequest)};
    }



}
