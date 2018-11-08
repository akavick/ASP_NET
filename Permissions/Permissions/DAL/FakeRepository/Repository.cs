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
            _permissions.Add(new Permission { PermissionId = 1, Title = "Access" });

            _permissions.Add(new Permission { PermissionId = 2, Title = "ViewRequest" });
            _permissions.Add(new Permission { PermissionId = 3, Title = "EditRequest" });
            _permissions.Add(new Permission { PermissionId = 4, Title = "RevokeRequest" });

            _permissions.Add(new Permission { PermissionId = 5, Title = "ApproveRequest" });
            _permissions.Add(new Permission { PermissionId = 6, Title = "RejectRequest" });

            //_permissions.Add(new Permission { PermissionId = 9, Title = "FullAccessToRequest" });

            _permissions.Add(new Permission { PermissionId = 7, Title = "ViewComment" });
            _permissions.Add(new Permission { PermissionId = 8, Title = "EditComment" });

            


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
            //adminRole.Permissions.AddRange(_permissions);


            var akavick = new Principal { PrincipalId = 1, Name = @"MINSK\akavick" };
            akavick.Roles.Add(pmRole);
            _principals.Add(akavick);

            var maul = new Principal { PrincipalId = 2, Name = @"MINSK\maul" };
            maul.Roles.Add(smdRole);
            _principals.Add(maul);

            var arba = new Principal { PrincipalId = 3, Name = @"MINSK\arba" };
            arba.Roles.Add(adminRole);
            _principals.Add(arba);


            _requests.Add(new Request{ RequestId = 30000001, Author = akavick, Status = RequestStatuses.New      });
            _requests.Add(new Request{ RequestId = 30000002, Author = maul,    Status = RequestStatuses.Approved });
            _requests.Add(new Request{ RequestId = 30000003, Author = akavick, Status = RequestStatuses.Approved });
            _requests.Add(new Request{ RequestId = 30000004, Author = akavick, Status = RequestStatuses.Rejected });
            _requests.Add(new Request{ RequestId = 30000005, Author = arba,    Status = RequestStatuses.New      });
            _requests.Add(new Request{ RequestId = 30000006, Author = akavick, Status = RequestStatuses.Approved });
            _requests.Add(new Request{ RequestId = 30000007, Author = akavick, Status = RequestStatuses.Rejected });
            _requests.Add(new Request{ RequestId = 30000008, Author = akavick, Status = RequestStatuses.New      });
            _requests.Add(new Request{ RequestId = 30000009, Author = maul,    Status = RequestStatuses.New      });
            _requests.Add(new Request{ RequestId = 30000010, Author = arba,    Status = RequestStatuses.New      });


            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 7, ObjectId = 20011001 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 7, ObjectId = 20021001 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 7, ObjectId = 20021002 });

            //чужие заявки - просмотр
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 2, ObjectId = 30000002 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 2, ObjectId = 30000005 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 2, ObjectId = 30000009 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 2, ObjectId = 30000010 });

            //свои заявки - просмотр, редактирование, отзыв
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 2, ObjectId = 30000001 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 2, ObjectId = 30000003 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 2, ObjectId = 30000004 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 2, ObjectId = 30000006 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 2, ObjectId = 30000007 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 2, ObjectId = 30000008 });

            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 3, ObjectId = 30000001 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 3, ObjectId = 30000003 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 3, ObjectId = 30000004 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 3, ObjectId = 30000006 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 3, ObjectId = 30000007 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 3, ObjectId = 30000008 });

            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 4, ObjectId = 30000001 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 4, ObjectId = 30000003 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 4, ObjectId = 30000004 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 4, ObjectId = 30000006 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 4, ObjectId = 30000007 });
            _mapUnits.Add(new MapUnit { PrincipalId = akavick.PrincipalId, PermissionId = 4, ObjectId = 30000008 });


        }



        public IEnumerable<Permission> Permissions => _permissions;

        public IEnumerable<Principal> Principals => _principals;

        public IEnumerable<Request> Requests => _requests;

        public IEnumerable<MapUnit> MapUnits => _mapUnits;

        public IEnumerable<Role> Roles => _roles;
    }

}