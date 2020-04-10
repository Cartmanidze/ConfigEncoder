namespace ConfigEncoder.Core
{
    /// <summary>
    /// Сервис логирования
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        /// <param name="msg">Сообщение</param>
        void Error(string msg);

        /// <summary>
        /// Сообщение о предупреждении
        /// </summary>
        /// <param name="msg">Сообщение</param>
        void Warn(string msg);

        /// <summary>
        /// Информативное сообщение
        /// </summary>
        /// <param name="msg">Сообщение</param>
        void Info(string msg);
    }
}
