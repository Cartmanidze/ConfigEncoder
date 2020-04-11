using System;
using ConfigEncoder.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace ConfigEncoder.Core.Services
{
    public class BaseEncryptionService : BaseService, IEncryptionService
    {
        public BaseEncryptionService(ILogger<BaseService> logger) : base(logger)
        {
        }

        public bool Encryption(object config, string key)
        {
            throw new NotImplementedException();
        }
    }
}
