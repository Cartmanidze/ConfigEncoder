namespace ConfigEncoder.Core.Interfaces
{
    /// <summary>
    /// Сервис шифрования
    /// </summary>
    public interface IEncryptionService : IServices
    {
        /// <summary>
        /// Шифрование
        /// </summary>
        /// <param name="config">Конфигурация</param>
        /// <param name="key">Ключ</param>
        void Encryption(object config, string key);
    }
}
