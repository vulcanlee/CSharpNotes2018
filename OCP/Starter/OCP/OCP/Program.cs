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
        public void GenerateEvent(string message)
        {
            Logger fooLogger = new Logger();
            fooLogger.Log(message);
        }
    }

    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
