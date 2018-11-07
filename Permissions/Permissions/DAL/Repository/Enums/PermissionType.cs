namespace Permissions.DAL.Repository.Enums
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
