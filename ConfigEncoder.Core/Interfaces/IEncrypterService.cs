namespace ConfigEncoder.Core.Interfaces
{
    /// <summary>
    /// Сервис шифрования
    /// </summary>
    public interface IEncrypterService : IServices
    {
        /// <summary>
        /// Шифрование
        /// </summary>
        /// <param name="config">Конфигурация</param>
        /// <param name="key">Ключ</param>
        bool Encryption(object config, string key);
    }
}
