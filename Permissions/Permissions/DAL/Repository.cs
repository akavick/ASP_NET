using System.Collections.Generic;
using System.Linq;


using Permissions.Models;



namespace Permissions.DAL
{

    public static class Repository
    {
        private static readonly List<Permission> _permissions = new List<Permission>();

        private static readonly List<Principal> _principals = new List<Principal>();

        private static readonly List<Request> _requests = new List<Request>();

        private static readonly List<MapUnit> _mapUnits = new List<MapUnit>();



        static Repository()
        {
            _principals.Add(new Principal{ PrincipalId = 1, Name = @"MINSK\akavick" });
            _principals.Add(new Principal{ PrincipalId = 2, Name = @"MINSK\user2" });
            _principals.Add(new Principal{ PrincipalId = 3, Name = @"MINSK\user3" });

            _requests.Add(new Request{ RequestId = 1, AuthorId = 1, Status = RequestStatuses.New });
            _requests.Add(new Request{ RequestId = 2, AuthorId = 2, Status = RequestStatuses.Approved });
            _requests.Add(new Request{ RequestId = 3, AuthorId = 1, Status = RequestStatuses.Approved });
            _requests.Add(new Request{ RequestId = 4, AuthorId = 1, Status = RequestStatuses.Rejected });
            _requests.Add(new Request{ RequestId = 5, AuthorId = 3, Status = RequestStatuses.New });

            _permissions.Add(new Permission{ PermissionId = 1, Title = "view new requests" });
            _permissions.Add(new Permission{ PermissionId = 2, Title = "view approved requests" });
            _permissions.Add(new Permission{ PermissionId = 3, Title = "view rejected requests" });
            _permissions.Add(new Permission{ PermissionId = 4, Title = "view requests of all authors" });
            _permissions.Add(new Permission{ PermissionId = 5, Title = "access FirstPage" });
            _permissions.Add(new Permission{ PermissionId = 6, Title = "access SecondPage" });
            _permissions.Add(new Permission{ PermissionId = 7, Title = "access ThirdPage" });
            _permissions.Add(new Permission{ PermissionId = 8, Title = "can create requests" });
            _permissions.Add(new Permission{ PermissionId = 9, Title = "can approve requests" });
            _permissions.Add(new Permission{ PermissionId = 10, Title = "can reject requests" });
            _permissions.Add(new Permission{ PermissionId = 11, Title = "view comments" });

            _mapUnits.Add(new MapUnit{  });
        }



        public static IEnumerable<Permission> Permissions => _permissions;

        public static IEnumerable<Principal> Principals => _principals;

        public static IEnumerable<Request> Requests => _requests;

        public static IEnumerable<MapUnit> MapUnits => _mapUnits;
    }

}