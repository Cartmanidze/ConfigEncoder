namespace ConfigEncoder.Core.Interfaces
{
    /// <summary>
    /// Сервис валидации
    /// </summary>
    public interface IValidationService : IServices
    {
        /// <summary>
        /// Валидная конфигурация
        /// </summary>
        /// <param name="config">Конфигурация</param>
        /// <param name="key">Ключ секции</param>
        /// <returns>Флаг валидности</returns>
        bool IsValidConfiguration(object config, string key);
    }
}
