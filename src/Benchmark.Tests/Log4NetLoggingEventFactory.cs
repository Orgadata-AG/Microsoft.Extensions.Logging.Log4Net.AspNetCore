using log4net.Core;
using Microsoft.Extensions.Logging.Log4Net.AspNetCore.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Extensions.Logging
{
    /// <inheritdoc cref="ILog4NetLoggingEventFactory"/>
    public sealed class CachedLog4NetLoggingEventFactory
        : ILog4NetLoggingEventFactory
    {
        private readonly Type callerStackBoundaryDeclaringType = typeof(LoggerExtensions);

        /// <inheritdoc/>
        public LoggingEvent CreateLoggingEvent<TState>(in MessageCandidate<TState> messageCandidate, log4net.Core.ILogger logger, Log4NetProviderOptions options, IExternalScopeProvider scopeProvider)
        {
            string message = messageCandidate.Formatter(messageCandidate.State, messageCandidate.Exception);
            Level logLevel = options.LogLevelTranslator.TranslateLogLevel(messageCandidate.LogLevel, options);

            if (logLevel == null || (string.IsNullOrEmpty(message) && messageCandidate.Exception == null))
                return null;

            var loggingEvent = new LoggingEvent(
                callerStackBoundaryDeclaringType: callerStackBoundaryDeclaringType,
                repository: logger.Repository,
                loggerName: logger.Name,
                level: logLevel,
                message: message,
                exception: messageCandidate.Exception);

            EnrichWithScopes(loggingEvent, scopeProvider);

            return loggingEvent;
        }

        private static void EnrichWithScopes(LoggingEvent loggingEvent, IExternalScopeProvider scopeProvider)
        {
            scopeProvider.ForEachScope((scope, @event) =>
            {
                // Because string implements IEnumerable we first need to check for string.
                if (scope is string)
                {
                    @event.Properties["scope"] = scope.ToString();
                    return;
                }

                if (scope is IEnumerable col)
                {
                    foreach (var item in col)
                    {
                        if (item is KeyValuePair<string, string>)
                        {
                            var keyValuePair = (KeyValuePair<string, string>)item;
                            string previousValue = @event.Properties[keyValuePair.Key] as string ?? "";
                            @event.Properties[keyValuePair.Key] = previousValue + keyValuePair.Value;
                            continue;
                        }

                        if (item is KeyValuePair<string, object>)
                        {
                            var keyValuePair = (KeyValuePair<string, object>)item;
                            string previousValue = @event.Properties[keyValuePair.Key] as string ?? "";
                            @event.Properties[keyValuePair.Key] = previousValue + keyValuePair.Value?.ToString();
                            continue;
                        }
                    }
                    return;
                }

                if (scope is object)
                {
                    @event.Properties["scope"] = scope.ToString();
                    return;
                }

            }, loggingEvent);
        }
    }
}
