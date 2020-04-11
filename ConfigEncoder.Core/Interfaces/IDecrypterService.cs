﻿namespace ConfigEncoder.Core.Interfaces
{
    /// <summary>
    /// Сервис дешифрования
    /// </summary>
    public interface IDecryprterService : IServices
    {
        /// <summary>
        /// Дешифрование 
        /// </summary>
        /// <param name="config">Конфигурация</param>
        /// <param name="key">Ключ секции</param>
        bool Decryption(object config, string key);
    }
}
