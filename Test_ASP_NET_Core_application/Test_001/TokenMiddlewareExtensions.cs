using Microsoft.AspNetCore.Builder;

namespace Test_001
{
    public static class TokenMiddlewareExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern, string name = LegalNames.TokenName)
        {
            return builder.UseMiddleware<TokenMiddleware>(pattern, name);
        }
    }
}