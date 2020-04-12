using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigEncoder.Data
{
    /// <summary>
    /// Конфигурационная секция
    /// </summary>
    public interface ISection
    {
        string Key { get; set; }
    }
}
