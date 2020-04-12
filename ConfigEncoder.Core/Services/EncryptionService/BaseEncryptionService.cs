using System;
using System.Configuration;
using ConfigEncoder.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace ConfigEncoder.Core.Services
{
    public class BaseEncryptionService : BaseService, IEncryptionService
    {
        private const string _provider = "RsaProtectedConfigurationProvider";

        private string _sectionName;

        public BaseEncryptionService(ILogger<BaseService> logger) : base(logger)
        {
        }

        public void Encryption(object config, string key)
        {
            try
            {
                var isEncryption = EncryptionProcessing(config, key);
                CheckEncryption(isEncryption);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Ошибка при шифровании секции {_sectionName} : {ex.Message}");
                throw;
            }
        }

        private void CheckEncryption(bool isEncryption)
        {
            if (isEncryption)
            {
                Logger.LogInformation($"Секция {_sectionName} зашифрованна");
            }
            else
            {
                Logger.LogWarning($"Не удалось получить секцию {_sectionName}, шифрование не выполнено");
            }
        }

        private bool EncryptionProcessing(object config, string key)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));
            if (!(config is Configuration reducedConfig)) return false;
            ConfigurationSection section = reducedConfig.GetSection(key);
            if (section == null) return false;
            _sectionName = section.SectionInformation.SectionName;
            section.SectionInformation.ProtectSection(_provider);
            section.SectionInformation.ForceSave = true;
            reducedConfig.Save(ConfigurationSaveMode.Full);
            return true;
        }
    }
}
