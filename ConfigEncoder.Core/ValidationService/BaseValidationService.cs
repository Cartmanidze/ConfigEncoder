using System;
using System.Configuration;
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
            try
            {
                if (config == null) throw new ArgumentNullException(nameof(config));
                if (!(config is Configuration reducedConfig)) return false;
                return IsValidSectionKey(key) && (!IsProtected(reducedConfig, key) && !IsLocked(reducedConfig, key));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Ошибка валидации : {ex.Message}");
                throw;
            }
        }

        private bool IsLocked(Configuration config, string sectionKey)
        {
            ConfigurationSection section = config.GetSection(sectionKey);
            if (section.SectionInformation.IsLocked)
            {
                Logger.LogWarning($"Секция {section.SectionInformation.SectionName} заблокирована от шифрования");
            }
            return section.SectionInformation.IsLocked;
        }

        private bool IsValidSectionKey(string sectionKey)
        {
            if (!string.IsNullOrEmpty(sectionKey) && !string.IsNullOrWhiteSpace(sectionKey))
            {
                Logger.LogWarning($"Ключ {sectionKey} не валиден");
            }
            return !string.IsNullOrEmpty(sectionKey) && !string.IsNullOrWhiteSpace(sectionKey);
        }

        private bool IsProtected(Configuration config, string sectionKey)
        {
            ConfigurationSection section = config.GetSection(sectionKey);
            if (section.SectionInformation.IsProtected)
            {
                Logger.LogWarning($"Секция {section.SectionInformation.SectionName} защищена от шифрования");
            }
            return section.SectionInformation.IsProtected;
        }
    }
}
