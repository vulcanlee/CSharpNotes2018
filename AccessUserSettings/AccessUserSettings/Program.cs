using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessUserSettings
{
    public interface IMessage
    {
        void Send(string message);
    }
    public class SMSMessage : IMessage
    {
        public void Send(string message)
        {
            Console.WriteLine($"簡訊已經送出 : {message}");
        }
    }
    public class EMailMessage : IMessage
    {
        public void Send(string message)
        {
            Console.WriteLine($"郵件已經送出 : {message}");
        }
    }
    public class StaticFactory
    {
        public static IMessage GetMessage()
        {
            string fooValue = Properties.Settings.Default.IMessage;
            Type fooType = Type.GetType(fooValue);
            IMessage fooObject = Activator.CreateInstance(fooType) as IMessage;
            return fooObject;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IMessage messageObject = StaticFactory.GetMessage();
            messageObject.Send("我已經動態產生具體實作物件了");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
