using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Authorization
{
    public static class Permissions
    {
        public const string ViewResource = "ViewResource";

        public const string CanCreateRequests = "CanCreateRequests";
        public const string CanApproveRequests = "CanApproveRequests";
        public const string CanApproveThisRequest = "CanApproveThisRequest";
        public const string CanRejectRequests = "CanRejectRequests";
        public const string CanRejectApprovedRequests = "CanRejectApprovedRequests";
        public const string CanApproveRejectedRequests = "CanApproveRejectedRequests";
        public const string CanAddComments = "CanAddComments";
        public const string CanViewFirstPage = "CanViewFirstPage";
        public const string CanViewSecondPage = "CanViewSecondPage";
        public const string CanViewThirdPage = "CanViewThirdPage";
        public const string CanViewThisObject = "CanViewThisObject";
    }
}
