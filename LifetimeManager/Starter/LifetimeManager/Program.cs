using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace LifetimeManager
{
    public interface IMessage
    {
        void Write(string message);
    }
    public class ConsoleMessage : IMessage
    {
        public void Write(string message)
        {
            Console.WriteLine($"此物件的 HashCode {this.GetHashCode()}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IMessage, ConsoleMessage>("TransientLifetimeManager");
            container.RegisterType<IMessage, ConsoleMessage>("ContainerControlledLifetimeManager");

            IMessage messageTransientLifetimeManager1 = container.Resolve<IMessage>("TransientLifetimeManager");
            IMessage messageTransientLifetimeManager2 = container.Resolve<IMessage>("TransientLifetimeManager");
            messageTransientLifetimeManager1.Write("Hi TransientLifetimeManager 1");
            messageTransientLifetimeManager2.Write("Hi TransientLifetimeManager 2");

            IMessage messageContainerControlledLifetimeManager1 = container.Resolve<IMessage>("ContainerControlledLifetimeManager");
            IMessage messageContainerControlledLifetimeManager2 = container.Resolve<IMessage>("ContainerControlledLifetimeManager");
            messageContainerControlledLifetimeManager1.Write("Hi ContainerControlledLifetimeManager 1");
            messageContainerControlledLifetimeManager2.Write("Hi ContainerControlledLifetimeManager 2");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

        }
    }
}
