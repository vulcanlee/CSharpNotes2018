using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreIoCDI
{
    public interface IDefaultDependency
    {
        Guid MyProperty { get; set; }
        string InstanceFrom { get; set; }
        string InstanceName { get; set; }
    }

    public class MyDefaultClass1 : IDefaultDependency
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
        public string ClassName { get; set; } = "MyDefaultClass1";
        public string InstanceFrom { get; set; } = "";
        public string InstanceName { get; set; } = "";
    }
}
