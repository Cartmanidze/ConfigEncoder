using Microsoft.Extensions.Logging;

namespace ConfigEncoder.Core
{
    public abstract class BaseService
    {
        protected ILogger<BaseService> Logger { get; set; }
    }
}
