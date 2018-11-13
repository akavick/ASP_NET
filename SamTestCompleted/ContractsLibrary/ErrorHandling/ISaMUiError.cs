namespace ContractsLibrary.ErrorHandling
{



    /// <summary>
    /// Контракт для описания frontend-ошибок
    /// </summary>
    public interface ISaMUiError
    {
        /// <summary>
        /// Описание ошибки
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// JS - стэк
        /// </summary>
        string Stack { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// Аутентифицирован ли пользователь
        /// </summary>
        bool UserIsAuthenticated { get; set; }

        /// <summary>
        /// Какой тип аутентификации был использован
        /// </summary>
        string UserAuthenticationType { get; set; }

        /// <summary>
        /// Адрес страницы, где произошла проблема с интерфейсом или JS-модулем
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// JS-модуль, где произошла ошибка
        /// </summary>
        string FileName { get; set; }



        /// <summary>
        /// Детализированное представление ошибки
        /// </summary>
        /// <returns>рекомендуется: детализированное представление ошибки в виде (форматированной) строки</returns>
        string Detail();

    }



}
