using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigEncoder.Data
{
    /// <summary>
    /// Целевой объект конфигурации
    /// </summary>
    /// <typeparam name="TConfiguration">Тип объекта конфигурации</typeparam>
    public interface ICustomerConfiguration<TConfiguration> where TConfiguration : class
    {
        /// <summary>
        /// Объект конфигурации
        /// </summary>
        TConfiguration Configuration { get; set; }

        /// <summary>
        /// Секции конфигурации
        /// </summary>
        IEnumerable<ISection> Sections { get; set; }
    }
}
