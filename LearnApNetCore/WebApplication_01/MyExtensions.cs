using Microsoft.AspNetCore.Builder;





namespace WebApplication_01
{

    public static class MyExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder, string pattern = "")
        {
            return builder.UseMiddleware<MyMiddleware>(pattern);
        }
    }

}