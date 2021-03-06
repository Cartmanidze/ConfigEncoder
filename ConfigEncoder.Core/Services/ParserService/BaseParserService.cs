﻿using System;
using System.Collections;
using System.Configuration;
using ConfigEncoder.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace ConfigEncoder.Core.Services
{
    /// <summary>
    /// Базовая реализация парсера
    /// </summary>
    public class BaseParserService : BaseService, IParserService
    {
        public BaseParserService(ILogger<BaseService> logger) : base(logger)
        {

        }

        public IEnumerable Parser(object config)
        {
            try
            {
                return ParserProcessing(config);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Ошибка парсинга : {ex.Message}");
                throw;
            }
        }

        private IEnumerable ParserProcessing(object config)
        {
            object[] sectionKeys = null;
            if (config == null) throw new ArgumentNullException(nameof(config));
            if (!(config is Configuration reducedConfig)) return null;
            ConfigurationSectionCollection sections = reducedConfig.Sections;
            sectionKeys = new object[sections.Count];
            if (sections.Count <= 0) return null;
            for (var i = 0; i < sections.Count; i++)
            {
                var sectionKey = sections.GetKey(i);
                sectionKeys[i] = sectionKey;
                Logger.LogInformation($"{sectionKey} был добавлен");
            }
            return sectionKeys;
        }
    }
}