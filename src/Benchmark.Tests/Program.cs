using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using log4net.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Log4Net.AspNetCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Benchmark.Tests
{
    public class Program
    {
        // netcoreapp3.1;net5.0;net6.0;net461;net462;net47;net471;net472;net48
        [SimpleJob(RuntimeMoniker.NetCoreApp31)]
        [SimpleJob(RuntimeMoniker.Net50)]
        [SimpleJob(RuntimeMoniker.Net60)]
        [SimpleJob(RuntimeMoniker.Net461)]
        [SimpleJob(RuntimeMoniker.Net462)]
        [SimpleJob(RuntimeMoniker.Net47)]
        [SimpleJob(RuntimeMoniker.Net471)]
        [SimpleJob(RuntimeMoniker.Net472)]
        [SimpleJob(RuntimeMoniker.Net48)]
        [MemoryDiagnoser]
        public class AllocatingVsNonAllocating
        {
            private IEnumerable<KeyValuePair<string, string>> _formattingParameters;
            private Log4NetLoggingEventFactory _defaultFactory;
            private CachedLog4NetLoggingEventFactory _cachedFactory;
            private log4net.Core.ILogger _logger;
            private Log4NetProviderOptions _providerOptions;
            private LoggerExternalScopeProvider _scopeProvider;

            [GlobalSetup]
            public void Setup()
            {
                _formattingParameters = new KeyValuePair<string, string>[]
                {
                    new KeyValuePair<string, string>("key1", "value1"),
                    new KeyValuePair<string, string>("key1", "value1")
                };

                _defaultFactory = new Log4NetLoggingEventFactory();
                _cachedFactory = new CachedLog4NetLoggingEventFactory();
                _logger = new NullLogger();
                _providerOptions = new Log4NetProviderOptions
                {
                    LogLevelTranslator = new Log4NetLogLevelTranslator(),
                };
                _scopeProvider = new LoggerExternalScopeProvider();
            }

            [Benchmark(Baseline = true)]
            public LoggingEvent NormalCallStackBoundaryType()
            {
                var candidate = new MessageCandidate<IEnumerable<KeyValuePair<string, string>>>(
                    LogLevel.Critical,
                    new EventId(5),
                    _formattingParameters,
                    null,
                    (parameters, exception) => string.Join(" ", parameters.Select(p => p.Value))
                );

                return _defaultFactory.CreateLoggingEvent(in candidate, _logger, _providerOptions, _scopeProvider);
            }

            [Benchmark]
            public LoggingEvent CachedCallStackBoundaryType()
            {
                var candidate = new MessageCandidate<IEnumerable<KeyValuePair<string, string>>>(
                    LogLevel.Critical,
                    new EventId(5),
                    _formattingParameters,
                    null,
                    (parameters, exception) => string.Join(" ", parameters.Select(p => p.Value))
                );

                return _cachedFactory.CreateLoggingEvent(in candidate, _logger, _providerOptions, _scopeProvider);
            }
        }


        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<AllocatingVsNonAllocating>();
        }
    }
}
