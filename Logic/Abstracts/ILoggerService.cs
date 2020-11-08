using System;

namespace Logic.Abstracts
{
    public interface ILoggerService
    {
        void Error(Exception ex, string message = null);

        void Warning(string message);

        void Info(string message);
    }
}