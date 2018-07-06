using System;

namespace PolymorphismBehavior
{
    namespace ByInheritance
    {
        public class MyBaseClase
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public MyBaseClase()
            {
                Name = "Base Class Name";
                Address = "Base Class Address";
            }
        }

        public class MyDerivedClass : MyBaseClase
        {
            public MyDerivedClass()
            {
                //Name = "Derived Class Name";
                Address = "Derived Class Address";
            }
        }
    }
    namespace ByInheritancePolymorphismVirtualOverride
    {
        public class MyBaseClase
        {
            public virtual string Name { get; set; }
            public virtual string Address { get; set; }
            public MyBaseClase()
            {
                Name = "Base Class Name";
                Address = "Base Class Address";
            }
        }
        public class MyDerivedClass : MyBaseClase
        {
            public override string Name { get; set; }
            public override string Address { get; set; }
            public MyDerivedClass()
            {
                Name = "Derived Class Name";
                Address = "Derived Class Address";
            }
        }

    }
    namespace ByInheritancePolymorphismNew
    {
        public class MyBaseClase
        {
            public virtual string Name { get; set; }
            public virtual string Address { get; set; }
            public MyBaseClase()
            {
                Name = "Base Class Name";
                Address = "Base Class Address";
            }
        }
        public class MyDerivedClass : MyBaseClase
        {
            public new string Name { get; set; }
            public new string Address { get; set; }
            public MyDerivedClass()
            {
                Name = "Derived Class Name";
                Address = "Derived Class Address";
            }
        }

    }
    namespace ByInheritancePolymorphismMixVirtualAndNew
    {
        public class MyBaseClase
        {
            public virtual string Name { get; set; }
            public virtual string Address { get; set; }
            public int Age { get; set; }
            public MyBaseClase()
            {
                Name = "Base Class Name";
                Address = "Base Class Address";
                Age = 20;
            }
        }
        public class MyDerivedClass : MyBaseClase
        {
            public override string Name { get; set; }
            public new string Address { get; set; }
            public new int Age { get; set; }
            public MyDerivedClass()
            {
                Name = "Derived Class Name";
                Address = "Derived Class Address";
                Age = 50;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            #region 單純繼承之物件多型行為
            ByInheritance.MyDerivedClass fooMyDerivedClassObject = new ByInheritance.MyDerivedClass();
            ByInheritance.MyBaseClase fooMyBaseClassObject = fooMyDerivedClassObject as ByInheritance.MyBaseClase;

            Console.WriteLine("單純繼承之物件多型行為");
            Console.WriteLine($"型別為基底類別的本地變數之執行時期的型別為 : {fooMyBaseClassObject.GetType().Name} ");
            Console.WriteLine($"型別為衍生類別的本地變數之執行時期的型別為 : {fooMyDerivedClassObject.GetType().Name} ");
            Console.WriteLine($"型別為基底類別的本地變數之 Name 屬性值為 : {fooMyBaseClassObject.Name} ");
            Console.WriteLine($"型別為基底類別的本地變數之 Address 屬性值為 : {fooMyBaseClassObject.Address} ");
            Console.WriteLine($"型別為衍生類別的本地變數之 Name 屬性值為 : {fooMyDerivedClassObject.Name} ");
            Console.WriteLine($"型別為衍生類別的本地變數之 Address 屬性值為 : {fooMyDerivedClassObject.Address} ");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
            #endregion

            #region 繼承與多型覆寫之有使用 virtual / override 使用情況
            ByInheritancePolymorphismVirtualOverride.MyDerivedClass fooVirtualOverrideMyDerivedClassObject = new ByInheritancePolymorphismVirtualOverride.MyDerivedClass();
            ByInheritancePolymorphismVirtualOverride.MyBaseClase fooVirtualOverrideMyBaseClassObject = fooVirtualOverrideMyDerivedClassObject as ByInheritancePolymorphismVirtualOverride.MyBaseClase;

            Console.WriteLine("繼承與多型覆寫之有使用 virtual / override 使用情況");
            Console.WriteLine($"型別為基底類別的本地變數之執行時期的型別為 : {fooVirtualOverrideMyBaseClassObject.GetType().Name} ");
            Console.WriteLine($"型別為衍生類別的本地變數之執行時期的型別為 : {fooVirtualOverrideMyDerivedClassObject.GetType().Name} ");
            Console.WriteLine($"型別為基底類別的本地變數之 Name 屬性值為 : {fooVirtualOverrideMyBaseClassObject.Name} ");
            Console.WriteLine($"型別為基底類別的本地變數之 Address 屬性值為 : {fooVirtualOverrideMyBaseClassObject.Address} ");
            Console.WriteLine($"型別為衍生類別的本地變數之 Name 屬性值為 : {fooVirtualOverrideMyDerivedClassObject.Name} ");
            Console.WriteLine($"型別為衍生類別的本地變數之 Address 屬性值為 : {fooVirtualOverrideMyDerivedClassObject.Address} ");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
            #endregion

            #region 繼承與多型覆寫之有使用 new 使用情況
            ByInheritancePolymorphismNew.MyDerivedClass fooNewMyDerivedClassObject = new ByInheritancePolymorphismNew.MyDerivedClass();
            ByInheritancePolymorphismNew.MyBaseClase fooNewMyBaseClassObject = fooNewMyDerivedClassObject as ByInheritancePolymorphismNew.MyBaseClase;

            Console.WriteLine("繼承與多型覆寫之有使用 new 使用情況");
            Console.WriteLine($"型別為基底類別的本地變數之執行時期的型別為 : {fooNewMyBaseClassObject.GetType().Name} ");
            Console.WriteLine($"型別為衍生類別的本地變數之執行時期的型別為 : {fooNewMyDerivedClassObject.GetType().Name} ");
            Console.WriteLine($"型別為基底類別的本地變數之 Name 屬性值為 : {fooNewMyBaseClassObject.Name} ");
            Console.WriteLine($"型別為基底類別的本地變數之 Address 屬性值為 : {fooNewMyBaseClassObject.Address} ");
            Console.WriteLine($"型別為衍生類別的本地變數之 Name 屬性值為 : {fooNewMyDerivedClassObject.Name} ");
            Console.WriteLine($"型別為衍生類別的本地變數之 Address 屬性值為 : {fooNewMyDerivedClassObject.Address} ");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
            #endregion

            #region 繼承與多型覆寫之有使用 virtual / override / new 使用情況
            ByInheritancePolymorphismMixVirtualAndNew.MyDerivedClass fooMixVirtualAndNewMyDerivedClassObject = new ByInheritancePolymorphismMixVirtualAndNew.MyDerivedClass();
            ByInheritancePolymorphismMixVirtualAndNew.MyBaseClase fooMixVirtualAndNewMyBaseClassObject = fooMixVirtualAndNewMyDerivedClassObject as ByInheritancePolymorphismMixVirtualAndNew.MyBaseClase;

            Console.WriteLine("承與多型覆寫之有使用 virtual / override / new 使用情況");
            Console.WriteLine($"型別為基底類別的本地變數之執行時期的型別為 : {fooMixVirtualAndNewMyBaseClassObject.GetType().Name} ");
            Console.WriteLine($"型別為衍生類別的本地變數之執行時期的型別為 : {fooMixVirtualAndNewMyDerivedClassObject.GetType().Name} ");
            Console.WriteLine($"型別為基底類別的本地變數之 Name 屬性值為 : {fooMixVirtualAndNewMyBaseClassObject.Name} ");
            Console.WriteLine($"型別為基底類別的本地變數之 Address 屬性值為 : {fooMixVirtualAndNewMyBaseClassObject.Address} ");
            Console.WriteLine($"型別為基底類別的本地變數之 Age 屬性值為 : {fooMixVirtualAndNewMyBaseClassObject.Age} ");
            Console.WriteLine($"型別為衍生類別的本地變數之 Name 屬性值為 : {fooMixVirtualAndNewMyDerivedClassObject.Name} ");
            Console.WriteLine($"型別為衍生類別的本地變數之 Address 屬性值為 : {fooMixVirtualAndNewMyDerivedClassObject.Address} ");
            Console.WriteLine($"型別為衍生類別的本地變數之 Age 屬性值為 : {fooMixVirtualAndNewMyDerivedClassObject.Age} ");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
            #endregion

        }
    }
}
