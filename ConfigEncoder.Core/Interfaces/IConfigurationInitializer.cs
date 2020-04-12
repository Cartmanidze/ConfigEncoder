using System;
using System.Collections.Generic;
using System.Text;
using ConfigEncoder.Data;

namespace ConfigEncoder.Core.Interfaces
{
    /// <summary>
    /// Инициализация объекта конфигурации
    /// </summary>
    public interface IConfigurationInitializer<TConfiguration> where TConfiguration : class
    {
        /// <summary>
        /// Инициализация объекта конфигурации
        /// </summary>
        /// <param name="path">Путь до файла конфигурации</param>
        /// <returns>Объект конфигурации</returns>
        ICustomerConfiguration<TConfiguration> Initialize(string path);
    }
}
