using System;
using System.IO;
using Intelsoft.Niis.Ibd.Infrastructure.Serilog.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
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

            var logDB = configuration.MsSqlConnectionString;
            var sinkOpts = new MSSqlServerSinkOptions
            {
                TableName = "Logs",
                AutoCreateSqlTable = true
            };
            var columnOpts = new ColumnOptions();
            columnOpts.Store.Add(StandardColumn.LogEvent);
            columnOpts.LogEvent.DataLength = 2048;
            columnOpts.TimeStamp.NonClusteredIndex = true;

            loggerConfiguration.WriteTo
                .MSSqlServer(
                    connectionString: logDB,
                    sinkOptions: sinkOpts,
                    columnOptions: columnOpts);

            loggerConfiguration.WriteTo.Console(theme: AnsiConsoleTheme.Code);

            return loggerConfiguration;
        }
    }
}