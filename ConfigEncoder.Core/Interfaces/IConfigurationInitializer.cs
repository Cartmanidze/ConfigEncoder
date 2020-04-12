using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigEncoder.Core.Interfaces
{
    /// <summary>
    /// Инициализация объекта конфигурации
    /// </summary>
    public interface IConfigurationInitializer
    {
        /// <summary>
        /// Инициализация объекта конфигурации
        /// </summary>
        /// <param name="path">Путь до файла конфигурации</param>
        /// <returns>Объект конфигурации</returns>
        object Initialize(string path);
    }
}
