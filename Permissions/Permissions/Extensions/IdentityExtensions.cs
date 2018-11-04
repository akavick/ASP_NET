using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Permissions.Extensions
{
    public static class IdentityExtensions
    {
        public static void AddOrRewriteClaim(this ClaimsIdentity claimsIdentity, string claimType, string claimValue)
        {
            if (!claimsIdentity.HasClaim(c => c.Type == claimType))
            {
                claimsIdentity.AddClaim(new Claim(claimType, claimValue));
            }
        }

        public static void AddOrRewriteClaim(this ClaimsIdentity claimsIdentity, string claimType, string claimValue, string claimValueType)
        {
            if (!claimsIdentity.HasClaim(c => c.Type == claimType))
            {
                claimsIdentity.AddClaim(new Claim(claimType, claimValue, claimValueType));
            }
        }

        public static void AddOrRewriteClaim(this ClaimsIdentity claimsIdentity, Claim claim)
        {
            if (!claimsIdentity.HasClaim(c => c.Type == claim.Type))
            {
                claimsIdentity.AddClaim(claim);
            }
        }
    }
}
