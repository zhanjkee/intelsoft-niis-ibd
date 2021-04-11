using System;
using System.IO;
using Intelsoft.Niis.Ibd.Infrastructure.Serilog.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Intelsoft.Niis.Ibd.Infrastructure.Logging
{
    public class SerilogLoggerFactory
    {
        private readonly SerilogConfiguration _configuration;

        public SerilogLoggerFactory(SerilogConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ILogger CreateLogger()
        {
            return CreateConfiguration(_configuration).CreateLogger();
        }

        private static LoggerConfiguration CreateConfiguration(SerilogConfiguration configuration)
        {
            var loggerConfiguration = new LoggerConfiguration()
                .Enrich.FromLogContext();

            var currentDirectory = Directory.GetCurrentDirectory();

            var logDirectory = Path.Combine(currentDirectory, configuration.LogPath);
            if (!Directory.Exists(logDirectory)) Directory.CreateDirectory(logDirectory);

            var todayDate = DateTime.UtcNow.ToString("yyyyMMdd");

            loggerConfiguration.WriteTo.Map(
                    evt => evt.Level,
                    (level, wt) => wt.File(
                        Path.Combine(logDirectory, $"{todayDate}_{level.ToString().ToLower()}.txt"),
                        level,
                        rollOnFileSizeLimit: true,
                        fileSizeLimitBytes: configuration.FileSizeLimitMBytes * 1024 * 1024));

            loggerConfiguration.WriteTo.Console(theme: AnsiConsoleTheme.Code);

            return loggerConfiguration;
        }
    }
}