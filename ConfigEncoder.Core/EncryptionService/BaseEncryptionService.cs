using System;
using System.Configuration;
using ConfigEncoder.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace ConfigEncoder.Core.Services
{
    public class BaseEncryptionService : BaseService, IEncryptionService
    {
        private const string _provider = "RsaProtectedConfigurationProvider";

        public BaseEncryptionService(ILogger<BaseService> logger) : base(logger)
        {
        }

        public bool Encryption(object config, string key)
        {
            try
            {
                return EncryptionProcessing(config, key);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Ошибка : {ex.Message}");
                throw;
            }
        }

        private bool EncryptionProcessing(object config, string key)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));
            if (!(config is Configuration reducedConfig)) return false;
            ConfigurationSection section = reducedConfig.GetSection(key);
            if (section == null) return false;
            Logger.LogInformation($"{section} получено");
            section.SectionInformation.ProtectSection(_provider);
            section.SectionInformation.ForceSave = true;
            reducedConfig.Save(ConfigurationSaveMode.Full);
            return true;
        }
    }
}
