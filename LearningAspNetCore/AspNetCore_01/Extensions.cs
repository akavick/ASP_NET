using Microsoft.AspNetCore.Builder;





namespace AspNetCore_01
{
    public static class Extensions
    {
        public static IApplicationBuilder UseTestMiddleware(this IApplicationBuilder builder, string pattern = "")
        {
            var applicationBuilder = builder.UseMiddleware<TestMiddleware>(pattern);

            return applicationBuilder;
        }
    }
}
