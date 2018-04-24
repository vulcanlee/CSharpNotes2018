using System;
using System.Collections.Generic;

namespace PoorManDIContainer
{
    public interface IMessage
    {
        void Write(string message);
    }
    public class ConsoleMessage : IMessage
    {
        public void Write(string message)
        {
            Console.WriteLine($"訊息: {message} 已經寫入到螢幕上了");
        }
    }
    public class FileMessage : IMessage
    {
        public void Write(string message)
        {
            Console.WriteLine($"訊息: {message} 已經寫入到檔案上了");
        }
    }
    public static class MyContainer
    {
        static readonly Dictionary<Type, Type> Maps = new Dictionary<Type, Type>();

        public static void Register<TAbstractType, TConcreteType>()
        {
            Maps[typeof(TAbstractType)] = typeof(TConcreteType);
        }

        public static TAbstractType Resolve<TAbstractType>()
        {
            Type fooConcreteType = Maps[typeof(TAbstractType)];
            Object instance = Activator.CreateInstance(fooConcreteType);
            return (TAbstractType)instance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyContainer.Register<IMessage, ConsoleMessage>();

            SendMessage("Hi Poor DI Container");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

        }

        private static void SendMessage(string message)
        {
            var fooConcrete = MyContainer.Resolve<IMessage>();
            fooConcrete.Write(message);
        }
    }
}
