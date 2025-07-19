using Microsoft.Extensions.Logging;
using System;

namespace SignalR_BE.Logging
{
    public class MyCustomLogger<T> : ILogger<T>
    {
        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Console.WriteLine($"[{logLevel}] {formatter(state, exception)} Error: {exception?.Message}");
        }
    }
}