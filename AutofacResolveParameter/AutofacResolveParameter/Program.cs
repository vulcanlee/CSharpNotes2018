using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacResolveParameter
{
    public interface IMessage
    {
        void Write(string message);
    }

    public class ConsoleMessage : IMessage
    {
        string _Name;
        int _Age;
        public ConsoleMessage(string name, int age)
        {
            _Name = name;
            _Age = age;
        }
        public void Write(string message)
        {
            Console.WriteLine($"[{_Name}, {_Age}] 訊息: {message} 已經寫入到螢幕上了");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 準備建立型別對應註冊的工作
            var builder = new ContainerBuilder();
            // 進行抽象型別與具體實作類別的註冊
            builder.RegisterType<ConsoleMessage>().As<IMessage>()
                .WithParameter("name", "Awesome")
                .WithParameter("age", 18);


            // 這裡將會建立 DI 容器
            IContainer container = builder.Build();

            // 進行抽象型別的具體實作物件的解析
            IMessage message = container.Resolve<IMessage>();

            // 執行取得物件的方法
            message.Write("Hi Vulcan");

            // 進行抽象型別的具體實作物件的解析
            IMessage messageParameter = container.Resolve<IMessage>(
                new NamedParameter("name", "Oh..No"),
                new NamedParameter("age", 77));

            // 執行取得物件的方法
            messageParameter.Write("Hi Vulcan");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
