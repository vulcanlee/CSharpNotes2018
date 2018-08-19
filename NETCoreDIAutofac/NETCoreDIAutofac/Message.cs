using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreDIAutofac
{
    public interface IMessage
    {
        void Send(string message);
    }

    public class ConsoleMessage : IMessage
    {
        public void Send(string message)
        {
            Console.WriteLine($"ConsoleMessage :{message}");
        }
    }
    public class FileMessage : IMessage
    {
        public void Send(string message)
        {
            Console.WriteLine($"FileMessage :{message}");
        }
    }
}
