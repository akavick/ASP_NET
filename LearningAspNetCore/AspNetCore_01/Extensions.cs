using Microsoft.AspNetCore.Builder;





namespace AspNetCore_01
{

    public static class Extensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern, string name = LegalNames.TokenName)
        {
            var applicationBuilder = builder.UseMiddleware<TokenMiddleware>(pattern, name);

            return applicationBuilder;
        }





        public static string Div(this string val)
        {
            return $"<div>{val}</div>";
        }





        public static string Header(this string val, int number = 1)
        {
            return $"<h{number}>{val}</h{number}>";
        }
    }


}
