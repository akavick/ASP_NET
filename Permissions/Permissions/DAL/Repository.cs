using System.Collections.Generic;
using System.Linq;


using Permissions.Models;



namespace Permissions.DAL
{

    public class Repository
    {
        private readonly List<Permission> _permissions = new List<Permission>();

        private readonly List<Principal> _principals = new List<Principal>();

        private readonly List<Request> _requests = new List<Request>();

        private readonly List<MapUnit> _mapUnits = new List<MapUnit>();



        public Repository()
        {
            _principals.Add(new Principal{ PrincipalId = 1, Name = @"MINSK\akavick" });
            _principals.Add(new Principal{ PrincipalId = 2, Name = @"MINSK\maul" });
            _principals.Add(new Principal{ PrincipalId = 3, Name = @"MINSK\arba" });

            _requests.Add(new Request{ RequestId = 1,  AuthorId = 1, Author = _principals[0], Status = RequestStatuses.New });
            _requests.Add(new Request{ RequestId = 2,  AuthorId = 2, Author = _principals[1], Status = RequestStatuses.Approved });
            _requests.Add(new Request{ RequestId = 3,  AuthorId = 1, Author = _principals[0], Status = RequestStatuses.Approved });
            _requests.Add(new Request{ RequestId = 4,  AuthorId = 1, Author = _principals[0], Status = RequestStatuses.Rejected });
            _requests.Add(new Request{ RequestId = 5,  AuthorId = 3, Author = _principals[2], Status = RequestStatuses.New });
            _requests.Add(new Request{ RequestId = 6,  AuthorId = 1, Author = _principals[0], Status = RequestStatuses.Approved });
            _requests.Add(new Request{ RequestId = 7,  AuthorId = 1, Author = _principals[0], Status = RequestStatuses.Rejected});
            _requests.Add(new Request{ RequestId = 8,  AuthorId = 1, Author = _principals[0], Status = RequestStatuses.New });
            _requests.Add(new Request{ RequestId = 9,  AuthorId = 2, Author = _principals[1], Status = RequestStatuses.New });
            _requests.Add(new Request{ RequestId = 10, AuthorId = 3, Author = _principals[2], Status = RequestStatuses.New });

            _permissions.Add(new Permission { PermissionId = 1,  Title = "view new requests" });
            _permissions.Add(new Permission { PermissionId = 2,  Title = "view approved requests" });
            _permissions.Add(new Permission { PermissionId = 3,  Title = "view rejected requests" });
            _permissions.Add(new Permission { PermissionId = 4,  Title = "view requests of all authors" });
            _permissions.Add(new Permission { PermissionId = 5,  Title = "access FirstPage" });
            _permissions.Add(new Permission { PermissionId = 6,  Title = "access SecondPage" });
            _permissions.Add(new Permission { PermissionId = 7,  Title = "access ThirdPage" });
            _permissions.Add(new Permission { PermissionId = 8,  Title = "can create requests" });
            _permissions.Add(new Permission { PermissionId = 9,  Title = "can approve requests" });
            _permissions.Add(new Permission { PermissionId = 10, Title = "can reject requests" });
            _permissions.Add(new Permission { PermissionId = 11, Title = "view comments" });

            _mapUnits.Add(new MapUnit { MapUnitId = 1, PrincipalId = 1, PermissionId = 1,  ObjectId = 1 });
            _mapUnits.Add(new MapUnit { MapUnitId = 2, PrincipalId = 1, PermissionId = 2,  ObjectId = 1 });
            _mapUnits.Add(new MapUnit { MapUnitId = 3, PrincipalId = 1, PermissionId = 5,  ObjectId = 1 });
            _mapUnits.Add(new MapUnit { MapUnitId = 4, PrincipalId = 1, PermissionId = 6,  ObjectId = 1 });
            _mapUnits.Add(new MapUnit { MapUnitId = 5, PrincipalId = 1, PermissionId = 8,  ObjectId = 1 });
            _mapUnits.Add(new MapUnit { MapUnitId = 6, PrincipalId = 1, PermissionId = 9,  ObjectId = 1 });
            _mapUnits.Add(new MapUnit { MapUnitId = 7, PrincipalId = 1, PermissionId = 11, ObjectId = 1 });
        }



        public IEnumerable<Permission> Permissions => _permissions;

        public IEnumerable<Principal> Principals => _principals;

        public IEnumerable<Request> Requests => _requests;

        public IEnumerable<MapUnit> MapUnits => _mapUnits;
    }

}