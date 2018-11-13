using System;
using System.Threading.Tasks;



namespace ContractsLibrary.ErrorHandling
{


    /// <summary>
    /// Контракт сервиса обработки ошибок
    /// </summary>
    public interface ISaMErrorHandler
    {
        /// <summary>
        /// Обработать ошибку клиентской части
        /// </summary>
        /// <param name="uiError">ошибка клиентской части</param>
        void HandleUiError(ISaMUiError uiError);

        /// <summary>
        /// Асинхронно обработать ошибку клиентской части
        /// </summary>
        /// <param name="uiError">ошибка клиентской части</param>
        /// <param name="when">время фиксации ошибки</param>
        /// <returns>ожидаемая задача</returns>
        Task HandleUiErrorAsync(ISaMUiError uiError, DateTime when);

        /// <summary>
        /// Обработать исключение
        /// </summary>
        /// <param name="error">исключение</param>
        void HandleError(Exception error);

        /// <summary>
        /// Обработать исключение
        /// </summary>
        /// <param name="error">исключение</param>
        /// <param name="message">дополнительная информация</param>
        void HandleError(Exception error, string message);

        /// <summary>
        /// Обработать исключение
        /// </summary>
        /// <typeparam name="TModel">любой объект</typeparam>
        /// <param name="error">исключение</param>
        /// <param name="model">дополнительный объект для обработки</param>
        void HandleError<TModel>(Exception error, TModel model);

        /// <summary>
        /// Обработать исключение
        /// </summary>
        /// <typeparam name="TModel">любой объект</typeparam>
        /// <param name="error">исключение</param>
        /// <param name="model">дополнительный объект для обработки</param>
        /// <param name="message">дополнительная информация</param>
        void HandleError<TModel>(Exception error, TModel model, string message);

        /// <summary>
        /// Асинхронно обработать исключение
        /// </summary>
        /// <param name="error">исключение</param>
        /// <param name="when">время фиксации ошибки</param>
        /// <returns>ожидаемая задача</returns>
        Task HandleErrorAsync(Exception error, DateTime when);

        /// <summary>
        /// Асинхронно обработать исключение
        /// </summary>
        /// <param name="error">исключение</param>
        /// <param name="when">время фиксации ошибки</param>
        /// <param name="message">дополнительная информация</param>
        /// <returns>ожидаемая задача</returns>
        Task HandleErrorAsync(Exception error, DateTime when, string message);

        /// <summary>
        /// Асинхронно обработать исключение
        /// </summary>
        /// <typeparam name="TModel">любой объект</typeparam>
        /// <param name="error">исключение</param>
        /// <param name="when">время фиксации ошибки</param>
        /// <param name="model">дополнительный объект для обработки</param>
        /// <returns>ожидаемая задача</returns>
        Task HandleErrorAsync<TModel>(Exception error, DateTime when, TModel model);

        /// <summary>
        /// Асинхронно обработать исключение
        /// </summary>
        /// <typeparam name="TModel">любой объект</typeparam>
        /// <param name="error">исключение</param>
        /// <param name="when">время фиксации ошибки</param>
        /// <param name="model">дополнительный объект для обработки</param>
        /// <param name="message">дополнительная информация</param>
        /// <returns>ожидаемая задача</returns>
        Task HandleErrorAsync<TModel>(Exception error, DateTime when, TModel model, string message);

    }



}
