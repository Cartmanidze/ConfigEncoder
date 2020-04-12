using System;
using System.Configuration;
using ConfigEncoder.Core.Interfaces;

namespace ConfigEncoder.Core.Services
{
    public class BaseDecryptionService : BaseService, IDecryptionService
    {
        private string _sectionName;
        public BaseDecryptionService(ILogger<BaseService> logger) : base(logger)
        {
        }

        public void Decryption(object config, string key)
        {
            try
            {
                var isDecryption = DecryptionProcessing(config, key);
                CheckDecryption(isDecryption);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Ошибка при дешифровании секции {_sectionName} : {ex.Message}");
                throw;
            }
        }

        private void CheckDecryption(bool isDecryption)
        {
            if (isDecryption)
            {
                Logger.LogInformation($"Секция {_sectionName} дешифрованна");
            }
            else
            {
                Logger.LogWarning($"Не удалось получить секцию {_sectionName}, дешифрование не выполнено");
            }
        }

        private bool DecryptionProcessing(object config, string key)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));
            if (!(config is Configuration reducedConfig)) return false;
            ConfigurationSection section = reducedConfig.GetSection(key);
            _sectionName = section.SectionInformation.SectionName;
            section.SectionInformation.UnprotectSection();
            section.SectionInformation.ForceSave = true;
            reducedConfig.Save(ConfigurationSaveMode.Full);
            return true;
        }
    }
}
