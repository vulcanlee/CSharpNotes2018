using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace UnityInterception
{
    public interface IMessage
    {
        void Write(string message);
        void Empty();
    }
    public class ConsoleMessage : IMessage
    {
        public void Write(string message)
        {
            Console.WriteLine($"訊息: {message} 已經寫入到檔案上了");
        }
        public void Empty()
        {
            Console.WriteLine($"這是個空的方法");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IMessage, ConsoleMessage>();

            IMessage message = container.Resolve<IMessage>();
            message.Write("Hi Vulcan");
            message.Empty();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
