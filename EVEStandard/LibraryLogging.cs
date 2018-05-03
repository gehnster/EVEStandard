using Microsoft.Extensions.Logging;

namespace EVEStandard
{
    public static class LibraryLogging
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();
        public static ILogger CreateLogger<T>() =>
          LoggerFactory.CreateLogger<T>();
    }
}
