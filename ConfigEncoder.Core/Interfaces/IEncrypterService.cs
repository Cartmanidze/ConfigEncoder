namespace ConfigEncoder.Core
{
    /// <summary>
    /// Сервис шифрования
    /// </summary>
    public interface IEncrypterService
    {
        /// <summary>
        /// Шифрование
        /// </summary>
        /// <param name="config">Конфигурация</param>
        /// <param name="key">Ключ</param>
        bool Encryption(object config, string key);
    }
}
