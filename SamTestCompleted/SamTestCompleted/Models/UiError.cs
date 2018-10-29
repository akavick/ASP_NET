using ErrorHandler.Interfaces;



namespace SamTestCompleted.Models
{



    public class UiError : IUiError
    {
        public string Message { get; set; }

        public string Stack { get; set; }

        public string UserName { get; set; }

        public bool UserIsAuthenticated { get; set; }

        public string UserAuthenticationType { get; set; }

        public string Url { get; set; }
    }



}