using System;

namespace CarFactory.Custom
{
    interface ILogger<T>
    {
        // void Info( T message, LogLevel logLevel = LogLevel.INFO);
        // void Warn(T message, LogLevel logLevel = LogLevel.WARN);
        // void Debug(T message, LogLevel logLevel = LogLevel.DEBUG);
        // void Fatal(T message,LogLevel logLevel = LogLevel.FATAL);
        // void Error(T message,LogLevel logLevel = LogLevel.ERROR);
        // void log(Action<string> printMessage, string message);
        
        private void LogInFile(T message) {}

        private void LogInConsole( T message) {}
    }
    
}

public enum LogLevel
{
    INFO,
    WARN,
    DEBUG,
    FATAL,
    ERROR
}