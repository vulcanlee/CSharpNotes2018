using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessConfigurationManager
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
            // 這裡要加入 System.Configuration 組件參考
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string fooValue = appSettings["IMessage"] ;
            Type fooType = Type.GetType(fooValue);
            IMessage fooObject = Activator.CreateInstance(fooType) as IMessage;
            return fooObject;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region 取得指定完整的類型名稱
            var foo = typeof(SMSMessage);
            var bar = foo.AssemblyQualifiedName.ToString();
            Console.WriteLine(bar);
            #endregion

            IMessage messageObject = StaticFactory.GetMessage();
            messageObject.Send("我已經動態產生具體實作物件了");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
