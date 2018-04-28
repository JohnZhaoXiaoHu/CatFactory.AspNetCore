﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CatFactory.AspNetCore.Tests
{
    public static class LoggerMocker
    {
        public static ILogger<T> GetLogger<T>()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug)
                .AddConsole(LogLevel.Trace)
                .AddConsole(LogLevel.Information)
                .AddConsole(LogLevel.Warning)
                .AddConsole(LogLevel.Error);

            return serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger<T>();
        }
    }
}
