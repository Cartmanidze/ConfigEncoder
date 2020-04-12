using ConfigEncoder.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace ConfigEncoder.Core.Services
{
    public abstract class BaseService : IServices
    {
        public ILogger Logger { get; set; }

        protected BaseService(ILogger<BaseService> logger)
        {
            Logger = logger;
        }

    }
}
