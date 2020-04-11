namespace ConfigEncoder.Core.Interfaces
{
    /// <summary>
    /// Сервис дешифрования
    /// </summary>
    public interface IDecryptionService : IServices
    {
        /// <summary>
        /// Дешифрование 
        /// </summary>
        /// <param name="config">Конфигурация</param>
        /// <param name="key">Ключ секции</param>
        void Decryption(object config, string key);
    }
}
