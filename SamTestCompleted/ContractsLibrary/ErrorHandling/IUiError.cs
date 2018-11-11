namespace ContractsLibrary.ErrorHandling
{

    public interface IUiError
    {
        string Message { get; set; }

        string Stack { get; set; }

        string UserName { get; set; }

        bool UserIsAuthenticated { get; set; }

        string UserAuthenticationType { get; set; }

        string Url { get; set; }

        string ToMsgString();
    }

}
