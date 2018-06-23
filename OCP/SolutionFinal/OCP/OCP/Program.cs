using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    public class AppEvent
    {
        private readonly ILogger _Logger;

        public AppEvent(ILogger logger)
        {
            this._Logger = logger;
        }
        public void GenerateEvent(string message)
        {
            _Logger.Log(message);
        }
    }
    public interface ILogger
    {
        void Log(string message);
    }
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.WriteAllText("MyLog", message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
