using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using ConfigEncoder.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace ConfigEncoder.Core.ValidationService
{
    public class BaseValidationService : BaseService, IValidationService
    {
        public BaseValidationService(ILogger<BaseService> logger) : base(logger)
        {
        }

        public bool IsValidConfiguration(object config, string key)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));
            if (!(config is Configuration reducedConfig)) return false;
            return IsValidSectionKey(key) && (!IsProtected(reducedConfig, key) && !IsLocked(reducedConfig, key));
        }

        private bool IsLocked(Configuration config, string sectionKey)
        {
            ConfigurationSection section = config.GetSection(sectionKey);
            return section.SectionInformation.IsLocked;
        }

        private bool IsValidSectionKey(string sectionKey)
        {
            return !string.IsNullOrEmpty(sectionKey) && !string.IsNullOrWhiteSpace(sectionKey);
        }

        private bool IsProtected(Configuration config, string sectionKey)
        {
            ConfigurationSection section = config.GetSection(sectionKey);
            return section.SectionInformation.IsProtected;
        }
    }
}
