using System;
using Logic.Abstracts;

namespace Logic.Services
{
    public class LoggerService : ILoggerService
    {
        public void Error(Exception ex, string message = null)
        {
            
        }

        public void Warning(string message)
        {
        }

        public void Info(string message)
        {
        }
    }
}