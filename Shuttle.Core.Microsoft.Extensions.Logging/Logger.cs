using System;
using Microsoft.Extensions.Logging;
using Shuttle.Core.Contract;
using Shuttle.Core.Logging;

namespace Shuttle.Core.Microsoft.Extensions.Logging
{
    public class Logger : AbstractLog
    {
        private readonly ILogger _logger;

        public Logger(ILogger logger)
        {
            Guard.AgainstNull(logger,nameof(logger));
            
            _logger = logger;
        }

        public override void Verbose(string message)
        {
            if (!_logger.IsEnabled(global::Microsoft.Extensions.Logging.LogLevel.Trace))
            {
                return;
            }

            _logger.LogTrace($"VERBOSE: {message}");
        }

        public override void Trace(string message)
        {
            if (!_logger.IsEnabled(global::Microsoft.Extensions.Logging.LogLevel.Trace))
            {
                return;
            }

            _logger.LogTrace(message);
        }

        public override void Debug(string message)
        {
            if (!_logger.IsEnabled(global::Microsoft.Extensions.Logging.LogLevel.Debug))
            {
                return;
            }

            _logger.LogDebug(message);
        }

        public override void Information(string message)
        {
            if (!_logger.IsEnabled(global::Microsoft.Extensions.Logging.LogLevel.Information))
            {
                return;
            }

            _logger.LogInformation(message);
        }

        public override void Error(string message)
        {
            if (!_logger.IsEnabled(global::Microsoft.Extensions.Logging.LogLevel.Error))
            {
                return;
            }

            _logger.LogError(message);
        }

        public override void Fatal(string message)
        {
            if (!_logger.IsEnabled(global::Microsoft.Extensions.Logging.LogLevel.Critical))
            {
                return;
            }

            _logger.LogCritical(message);
        }

        public override ILog For(Type type)
        {
            return new Logger(new LoggerFactory().CreateLogger(type));
        }

        public override ILog For(object instance)
        {
            Guard.AgainstNull(instance, nameof(instance));
            
            return new Logger(new LoggerFactory().CreateLogger(instance.GetType()));
        }

        public override void Warning(string message)
        {
            if (!_logger.IsEnabled(global::Microsoft.Extensions.Logging.LogLevel.Warning))
            {
                return;
            }

            _logger.LogWarning(message);
        }
    }
}
