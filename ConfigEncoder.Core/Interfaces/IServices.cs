using Microsoft.Extensions.Logging;

namespace ConfigEncoder.Core.Interfaces
{
    /// <summary>
    /// Базовый интерфейс для сервисов
    /// </summary>
    public interface IServices
    {
        ILogger Logger { get; set; }
    }
}
