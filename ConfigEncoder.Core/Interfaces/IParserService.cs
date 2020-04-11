using System.Collections;

namespace ConfigEncoder.Core.Interfaces
{
    /// <summary>
    /// Сервис парсинга файла конфигурации
    /// </summary>
    public interface IParserService : IServices
    {
        /// <summary>
        /// Метод парсинга
        /// </summary>
        /// <param name="config">Конфигурация</param>
        /// <returns>Список секций</returns>
        IEnumerable Parser(object config);
    }
}
