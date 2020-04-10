namespace ConfigEncoder.Core
{
    /// <summary>
    /// Сервис дешифрования
    /// </summary>
    public interface IDecryprterService
    {
        /// <summary>
        /// Дешифрование 
        /// </summary>
        /// <param name="config">Конфигурация</param>
        /// <param name="key">Ключ секции</param>
        bool Decryption(object config, string key);
    }
}
