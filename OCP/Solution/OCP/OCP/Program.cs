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
            Logger fooLogger = new Logger("Console");
            fooLogger.Log(message);
        }
    }
    public class Logger
    {
        private readonly string _Target;

        public Logger(string target) { _Target = target; }
        public void Log(string message)
        {
            if (_Target == "Console")
                Console.WriteLine(message);
            else if (_Target == "File")
                File.WriteAllText("MyLog", message);
            else
                throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
