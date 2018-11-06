using System.Collections.Generic;

using Permissions.Models;



namespace Permissions.DAL.FakeRepository
{

    public class Repository
    {
        private readonly List<Permission> _permissions = new List<Permission>();

        private readonly List<Principal> _principals = new List<Principal>();

        private readonly List<Request> _requests = new List<Request>();

        private readonly List<MapUnit> _mapUnits = new List<MapUnit>();

        private readonly List<Role> _roles = new List<Role>();



        public Repository()
        {
            _permissions.Add(new Permission { PermissionId = 1, Title = "View request" });
            _permissions.Add(new Permission { PermissionId = 2, Title = "Edit request" });
            _permissions.Add(new Permission { PermissionId = 3, Title = "Approve request" });
            _permissions.Add(new Permission { PermissionId = 4, Title = "Reject request" });
            _permissions.Add(new Permission { PermissionId = 5, Title = "Create request" });
            _permissions.Add(new Permission { PermissionId = 6, Title = "View comments" });

            _permissions.Add(new Permission { PermissionId = 7, Title = "Access FirstPage" });
            _permissions.Add(new Permission { PermissionId = 8, Title = "Access SecondPage" });
            _permissions.Add(new Permission { PermissionId = 9, Title = "Access ThirdPage" });


            var employeeRole = new Role { RoleId = 1, Title = "Employee" };
            _roles.Add(employeeRole);

            var pmRole = new Role { RoleId = 2, Title = "PM" };
            _roles.Add(pmRole);
            //pmRole.Permissions.Add();

            var smdRole = new Role { RoleId = 3, Title = "SMD" };
            _roles.Add(smdRole);
            //smdRole.Permissions.AddRange(_permissions);

            var adminRole = new Role { RoleId = 4, Title = "Admin" };
            _roles.Add(adminRole);
            adminRole.Permissions.AddRange(_permissions);


            var akavick = new Principal { PrincipalId = 1, Name = @"MINSK\akavick" };
            akavick.Roles.Add(pmRole);
            _principals.Add(akavick);

            var maul = new Principal { PrincipalId = 2, Name = @"MINSK\maul" };
            maul.Roles.Add(smdRole);
            _principals.Add(maul);

            var arba = new Principal { PrincipalId = 3, Name = @"MINSK\arba" };
            arba.Roles.Add(adminRole);
            _principals.Add(arba);


            _requests.Add(new Request{ RequestId = 1,  Author = akavick, Status = RequestStatuses.New      });
            _requests.Add(new Request{ RequestId = 2,  Author = maul,    Status = RequestStatuses.Approved });
            _requests.Add(new Request{ RequestId = 3,  Author = akavick, Status = RequestStatuses.Approved });
            _requests.Add(new Request{ RequestId = 4,  Author = akavick, Status = RequestStatuses.Rejected });
            _requests.Add(new Request{ RequestId = 5,  Author = arba,    Status = RequestStatuses.New      });
            _requests.Add(new Request{ RequestId = 6,  Author = akavick, Status = RequestStatuses.Approved });
            _requests.Add(new Request{ RequestId = 7,  Author = akavick, Status = RequestStatuses.Rejected });
            _requests.Add(new Request{ RequestId = 8,  Author = akavick, Status = RequestStatuses.New      });
            _requests.Add(new Request{ RequestId = 9,  Author = maul,    Status = RequestStatuses.New      });
            _requests.Add(new Request{ RequestId = 10, Author = arba,    Status = RequestStatuses.New      });



            _mapUnits.Add(new MapUnit { MapUnitId = 1, PrincipalId = akavick.PrincipalId, PermissionId = 7, ObjectId = 1 });
            _mapUnits.Add(new MapUnit { MapUnitId = 2, PrincipalId = akavick.PrincipalId, PermissionId = 8, ObjectId = 1 });

            _mapUnits.Add(new MapUnit { MapUnitId = 3, PrincipalId = akavick.PrincipalId, PermissionId = 1,  ObjectId = 1 });
            _mapUnits.Add(new MapUnit { MapUnitId = 4, PrincipalId = akavick.PrincipalId, PermissionId = 2,  ObjectId = 1 });
            _mapUnits.Add(new MapUnit { MapUnitId = 5, PrincipalId = akavick.PrincipalId, PermissionId = 5,  ObjectId = 1 });
            _mapUnits.Add(new MapUnit { MapUnitId = 6, PrincipalId = akavick.PrincipalId, PermissionId = 6,  ObjectId = 1 });
            _mapUnits.Add(new MapUnit { MapUnitId = 7, PrincipalId = akavick.PrincipalId, PermissionId = 8,  ObjectId = 1 });
            _mapUnits.Add(new MapUnit { MapUnitId = 8, PrincipalId = akavick.PrincipalId, PermissionId = 9,  ObjectId = 1 });
            _mapUnits.Add(new MapUnit { MapUnitId = 9, PrincipalId = akavick.PrincipalId, PermissionId = 11, ObjectId = 1 });
        }



        public IEnumerable<Permission> Permissions => _permissions;

        public IEnumerable<Principal> Principals => _principals;

        public IEnumerable<Request> Requests => _requests;

        public IEnumerable<MapUnit> MapUnits => _mapUnits;

        public IEnumerable<Role> Roles => _roles;
    }

}