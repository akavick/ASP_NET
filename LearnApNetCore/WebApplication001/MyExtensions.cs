using Microsoft.AspNetCore.Builder;





namespace WebApplication001
{

    public static class MyExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }

}