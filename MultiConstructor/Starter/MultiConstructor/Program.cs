using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MultiConstructor
{
    interface IDependency1 { }
    class Dependency1 : IDependency1 { }
    interface IDependency2 { }
    class Dependency2 : IDependency2 { }
    interface IDependency3 { }
    class Dependency3 : IDependency3 { }
    interface IDependency4 { }
    class Dependency4 : IDependency4 { }
    interface IInfrastructure
    {
    }
    class Infrastructure : IInfrastructure
    {
        public Infrastructure(IDependency1 d1)
        { Console.WriteLine("使用了需要 1 個參數的建構函式來生成物件"); }
        public Infrastructure(IDependency1 d1, IDependency2 d2)
        { Console.WriteLine("使用了需要 2 個參數的建構函式來生成物件"); }
        public Infrastructure(IDependency1 d1, IDependency2 d2,
            IDependency3 d3)
        { Console.WriteLine("使用了需要 3 個參數的建構函式來生成物件"); }
        public Infrastructure(IDependency1 d1, IDependency2 d2,
            IDependency3 d3, IDependency4 d4)
        { Console.WriteLine("使用了需要 4 個參數的建構函式來生成物件"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IDependency1, Dependency1>();
            container.RegisterType<IDependency2, Dependency2>();
            container.RegisterType<IDependency3, Dependency3>();
            container.RegisterType<IDependency4, Dependency4>();
            container.RegisterType<IInfrastructure, Infrastructure>();

            container.Resolve<IInfrastructure>();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

        }
    }
}
