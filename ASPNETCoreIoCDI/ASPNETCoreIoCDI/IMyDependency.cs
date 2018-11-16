using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreIoCDI
{
    public interface IMyDependency
    {
        Guid MyProperty { get; set; }
        string InstanceFrom { get; set; }
        string InstanceName { get; set; }
    }

    public class MyClass1 : IMyDependency
    {
        Guid myProperty = Guid.NewGuid();

        public Guid MyProperty
        {
            get
            {
                return myProperty;
            }

            set
            {
                myProperty = value;
            }
        }
        public string ClassName { get; set; } = "MyClass1";
        public string InstanceFrom { get; set; } = "";
        public string InstanceName { get; set; } = "";
    }

    public class MyClass2 : IMyDependency
    {
        Guid myProperty = Guid.NewGuid();

        public Guid MyProperty
        {
            get
            {
                return myProperty;
            }

            set
            {
                myProperty = value;
            }
        }

        public string ClassName { get; set; } = "MyClass2";
        public string InstanceFrom { get; set; } = "";
        public string InstanceName { get; set; } = "";
    }
}
