using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExplicitImp
{
    interface IControl { void Paint(); }
    interface ISurface { void Paint(); }
    class SampleClass : IControl, ISurface
    {
        public void Paint()
        {
            Console.WriteLine("這是 SampleClass 的 Paint方法實作");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SampleClass foo1 = new SampleClass();
            IControl foo2 = (IControl)foo1;
            ISurface foo3 = (ISurface)foo1;
            foo1.Paint();
            foo2.Paint();
            foo3.Paint();


            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

        }
    }
}
