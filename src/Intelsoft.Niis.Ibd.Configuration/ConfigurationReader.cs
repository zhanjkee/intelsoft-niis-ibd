using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using Intelsoft.Niis.Ibd.Configuration.Base;
using Intelsoft.Niis.Ibd.Validation;

namespace Intelsoft.Niis.Ibd.Configuration
{
    public abstract class ConfigurationReader<TConfiguration> : IConfigurationReader<TConfiguration>
        where TConfiguration : class, IConfiguration
    {
        public TConfiguration Read(string sectionName)
        {
            var configuration = ConfigurationManager.GetSection(sectionName) as TConfiguration;

            if (!DataAnnotationsValidator.TryValidate(configuration, out var validationResults))
            {
                var validationExceptions = validationResults.Select(x => new ValidationException(x.ErrorMessage));
                var aggregatedException = new AggregateException(validationExceptions);

                throw new InvalidOperationException($"Unable to build {nameof(IConfiguration)}", aggregatedException);
            }

            return configuration;
        }
    }
}