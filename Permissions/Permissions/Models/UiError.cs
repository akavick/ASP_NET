using System;



namespace Permissions.Models
{

    public class UiError
    {
        public string Message { get; set; }

        public string Stack { get; set; }

        public string UserName { get; set; }

        public bool UserIsAuthenticated { get; set; }

        public string UserAuthenticationType { get; set; }

        public string Url { get; set; }



        public string ToMsgString()
        {
            var nl = Environment.NewLine;

            var msg = $"UI ERROR from url: {Url}{nl}"
                    + $"User: {UserName}{nl}"
                    + $"IsAuthenticated: {UserIsAuthenticated}{nl}"
                    + $"AuthenticationType: {UserAuthenticationType}{nl}"
                    + $"Message: {Message}{nl}"
                    + $"Stack: {Stack}{nl}";

            return msg;
        }

    }

}