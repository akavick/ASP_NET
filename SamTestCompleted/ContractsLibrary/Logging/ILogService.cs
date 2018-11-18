using System;
using System.Threading.Tasks;



namespace ContractsLibrary.Logging
{



    /// <summary>
    /// Контракт сервиса логирования
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// Подписать логгер
        /// </summary>
        /// <param name="logger">логгер</param>
        void Subscribe(ILogger logger);

        /// <summary>
        /// Залогировать отладочное сообщение
        /// </summary>
        /// <param name="debugMessage">отладочное сообщение</param>
        void LogDebug(string debugMessage);

        /// <summary>
        /// Залогировать сообщение трассировки
        /// </summary>
        /// <param name="traceMessage">сообщение трассировки</param>
        void LogTrace(string traceMessage);

        /// <summary>
        /// Залогировать информационное сообщение
        /// </summary>
        /// <param name="infoMessage">информационное сообщение</param>
        void LogInformation(string infoMessage);

        /// <summary>
        /// Залогировать предупреждение
        /// </summary>
        /// <param name="warningMessage">предупреждение</param>
        void LogWarning(string warningMessage);

        /// <summary>
        /// Залогировать ошибку
        /// </summary>
        /// <param name="errorMessage">сообщение об ошибке</param>
        /// <param name="exception">исключение</param>
        void LogError(string errorMessage, Exception exception = null);

        /// <summary>
        /// Залогировать критическую ошибку
        /// </summary>
        /// <param name="criticalErrorMessage">сообщение о критической ошибке</param>
        /// <param name="exception">исключение</param>
        void LogCriticalError(string criticalErrorMessage, Exception exception = null);

        /// <summary>
        /// Асинхронно залогировать отладочное сообщение
        /// </summary>
        /// <param name="debugMessage">отладочное сообщение</param>
        /// <param name="when">время фиксации</param>
        /// <returns></returns>
        Task LogDebugAsync(string debugMessage, DateTime when);

        /// <summary>
        /// Асинхронно залогировать сообщение трассировки
        /// </summary>
        /// <param name="traceMessage">сообщение трассировки</param>
        /// <param name="when">время фиксации</param>
        /// <returns></returns>
        Task LogTraceAsync(string traceMessage, DateTime when);

        /// <summary>
        /// Асинхронно залогировать информационное сообщение
        /// </summary>
        /// <param name="infoMessage">информационное сообщение</param>
        /// <param name="when">время фиксации</param>
        /// <returns></returns>
        Task LogInformationAsync(string infoMessage, DateTime when);

        /// <summary>
        /// Асинхронно залогировать предупреждение
        /// </summary>
        /// <param name="warning">предупреждение</param>
        /// <param name="when">время фиксации</param>
        /// <returns></returns>
        Task LogWarningAsync(string warning, DateTime when);

        /// <summary>
        /// Асинхронно залогировать ошибку
        /// </summary>
        /// <param name="errorMessage">сообщение об ошибке</param>
        /// <param name="when">время фиксации</param>
        /// <param name="exception">исключение</param>
        /// <returns></returns>
        Task LogErrorAsync(string errorMessage, DateTime when, Exception exception = null);

        /// <summary>
        /// Асинхронно залогировать критическую ошибку
        /// </summary>
        /// <param name="criticalErrorMessage">сообщение о критической ошибке</param>
        /// <param name="when">время фиксации</param>
        /// <param name="exception">исключение</param>
        /// <returns></returns>
        Task LogCriticalErrorAsync(string criticalErrorMessage, DateTime when, Exception exception = null);
    }



}
