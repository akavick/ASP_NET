using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Permissions.DAL;
using Permissions.DAL.FakeRepository;



namespace Permissions.Authorization
{



    public class AuthorizationLogic
    {
        private readonly Repository _repository;



        public AuthorizationLogic(Repository repository)
        {
            _repository = repository;
        }



        public void SetMyPermissions(IIdentity identity)
        {
            var user = _repository.Principals.FirstOrDefault(x => x.Name == identity.Name);

            if (user == null)
            {
                return;
            }

            var mapUnits = _repository.MapUnits.Where(x => x.PrincipalId == user.PrincipalId).ToList();
            var claimsIdentity = (ClaimsIdentity) identity;

            foreach (var mapUnit in mapUnits)
            {
                claimsIdentity.AddClaim(new Claim($"{mapUnit.ObjectId}", $"{mapUnit.PermissionId}"));
            }
        }
    }



}
