using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.DAL.Enums
{    
    public enum PermissionType
    {
        ViewNewRequests = 1,
        ViewApprovedRequests,
        ViewRejectedRequests,
        ViewRequestsOfAllAuthors,
        AccessFirstPage,
        AccessSecondPage,
        AccessThirdPage,
        CanCreateRequests,
        CanApproveRequests,
        CanRejectRequests,
        ViewComments

    }
}
