using System;
using System.Collections;
using System.Configuration;

namespace ConfigEncoder.Core.Services
{
    /// <summary>
    /// Базовая реализация парсера
    /// </summary>
    public abstract class BaseParserService : IParserService
    {
        public virtual IEnumerable Parser(object config)
        {
            object[] sectionKeys = null;
            if (config == null) throw new ArgumentNullException(nameof(config));
            if (config is Configuration reducedConfig)
            {
                ConfigurationSectionCollection sections = reducedConfig.Sections;
                sectionKeys = new object[sections.Count];
                if (sections.Count <= 0) return sectionKeys;
                for (int i = 0; i < sections.Count; i++)
                {
                    var sectionKey = sections.GetKey(i);
                    sectionKeys[i] = sectionKey;
                }
            }
            return sectionKeys;
        }
    }
}
