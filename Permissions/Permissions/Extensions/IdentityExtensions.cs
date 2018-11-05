using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Permissions.Extensions
{
    public static class IdentityExtensions
    {
        public static void AddClaim(this ClaimsIdentity claimsIdentity, string claimType, string claimValue)
        {
            claimsIdentity.AddClaim(new Claim(claimType, claimValue));
        }

        public static void AddClaim(this ClaimsIdentity claimsIdentity, string claimType, string claimValue, string claimValueType)
        {
            claimsIdentity.AddClaim(new Claim(claimType, claimValue, claimValueType));
        }

        //public static void AddClaim(this ClaimsIdentity claimsIdentity, Claim claim)
        //{
        //    claimsIdentity.AddClaim(claim);
        //}
    }
}
