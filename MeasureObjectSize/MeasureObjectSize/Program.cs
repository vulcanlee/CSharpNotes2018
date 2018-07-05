using System;

namespace MeasureObjectSize
{
    namespace ByInheritance
    {
        public class MyBaseClase
        {
            protected int[] Number { get; set; } = new int[1024];
        }

        public class MyEmptyClass
        {

        }
        public class MyDerivedClass : MyBaseClase
        {

        }
    }
    namespace ByInheritancePolymorphismOverride
    {
        public class MyBaseClase
        {
            protected virtual int[] Number { get; set; } = new int[1024];
        }
        public class MyEmptyClass
        {

        }
        public class MyDerivedClass : MyBaseClase
        {
            protected override int[] Number { get; set; } = new int[1024];
        }
    }
    namespace ByInheritancePolymorphismNew
    {
        public class MyBaseClase
        {
            protected int[] Number { get; set; } = new int[1024];
        }
        public class MyEmptyClass
        {

        }
        public class MyDerivedClass : MyBaseClase
        {
            protected new int[] number { get; set; } = new int[1024];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            long BeginMemoryUsage, ArrayMemoryUsage, 
                EmptyClassObjectMemoryUsage, BaseClassObjectMemoryUsage, DerivedClassObjectMemoryUsage;
            int[] localNumber;

            #region 量測 int[1024] 的耗用記憶體
            BeginMemoryUsage = GC.GetTotalMemory(true);
            localNumber = new int[1024];
            ArrayMemoryUsage = GC.GetTotalMemory(true);
            Console.WriteLine("量測 int[1024] 的耗用記憶體");
            Console.WriteLine($"int[1024] 耗用記憶體 : {ArrayMemoryUsage - BeginMemoryUsage} ");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
            #endregion

            #region 量測單純繼承之物件使用記憶體使用情況
            BeginMemoryUsage = GC.GetTotalMemory(true);
            ByInheritance.MyEmptyClass fooMyEmptyClass = new ByInheritance.MyEmptyClass();
            EmptyClassObjectMemoryUsage = GC.GetTotalMemory(true);
            ByInheritance.MyBaseClase fooMyBaseClassObject = new ByInheritance.MyBaseClase();
            BaseClassObjectMemoryUsage = GC.GetTotalMemory(true);
            ByInheritance.MyDerivedClass fooMyDerivedClassObject = new ByInheritance.MyDerivedClass();
            DerivedClassObjectMemoryUsage = GC.GetTotalMemory(true);

            Console.WriteLine("量測單純繼承之物件使用記憶體使用情況");
            Console.WriteLine($"產生空類別  之執行個體耗用記憶體 : {EmptyClassObjectMemoryUsage - BeginMemoryUsage} ");
            Console.WriteLine($"建立基底類別之執行個體耗用記憶體 : {BaseClassObjectMemoryUsage - EmptyClassObjectMemoryUsage} ");
            Console.WriteLine($"建立衍生類別之執行個體耗用記憶體 : {DerivedClassObjectMemoryUsage - BaseClassObjectMemoryUsage} ");
            Console.WriteLine($"衍生類別之執行個體 與 基底類別之執行個體 記憶體相差數量 : " +
                $"{(BaseClassObjectMemoryUsage - EmptyClassObjectMemoryUsage) - (DerivedClassObjectMemoryUsage - BaseClassObjectMemoryUsage)} ");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
            #endregion

            #region 量測繼承與多型覆寫之物件使用記憶體使用情況
            BeginMemoryUsage = GC.GetTotalMemory(true);
            ByInheritancePolymorphismOverride.MyEmptyClass fooInheritancePolymorphismMyEmptyClass = new ByInheritancePolymorphismOverride.MyEmptyClass();
            EmptyClassObjectMemoryUsage = GC.GetTotalMemory(true);
            ByInheritancePolymorphismOverride.MyBaseClase fooInheritancePolymorphismMyBaseClassObject = new ByInheritancePolymorphismOverride.MyBaseClase();
            BaseClassObjectMemoryUsage = GC.GetTotalMemory(true);
            ByInheritancePolymorphismOverride.MyDerivedClass fooInheritancePolymorphismMyDerivedClassObject = new ByInheritancePolymorphismOverride.MyDerivedClass();
            DerivedClassObjectMemoryUsage = GC.GetTotalMemory(true);

            var foo = (ByInheritancePolymorphismOverride.MyBaseClase)fooInheritancePolymorphismMyDerivedClassObject;

            Console.WriteLine("量測繼承與多型覆寫之物件使用記憶體使用情況");
            Console.WriteLine($"產生空類別  之執行個體耗用記憶體 : {EmptyClassObjectMemoryUsage - BeginMemoryUsage} ");
            Console.WriteLine($"建立基底類別之執行個體耗用記憶體 : {BaseClassObjectMemoryUsage - EmptyClassObjectMemoryUsage} ");
            Console.WriteLine($"建立衍生類別之執行個體耗用記憶體 : {DerivedClassObjectMemoryUsage - BaseClassObjectMemoryUsage} ");
            Console.WriteLine($"衍生類別之執行個體 與 基底類別之執行個體 記憶體相差數量 : " +
                $"{(DerivedClassObjectMemoryUsage - BaseClassObjectMemoryUsage)- (BaseClassObjectMemoryUsage - EmptyClassObjectMemoryUsage)} ");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
            #endregion

            #region 量測繼承與多型隱藏之物件使用記憶體使用情況
            BeginMemoryUsage = GC.GetTotalMemory(true);
            ByInheritancePolymorphismNew.MyEmptyClass fooInheritancePolymorphismNewMyEmptyClass = new ByInheritancePolymorphismNew.MyEmptyClass();
            EmptyClassObjectMemoryUsage = GC.GetTotalMemory(true);
            ByInheritancePolymorphismNew.MyBaseClase fooInheritancePolymorphismNewMyBaseClassObject = new ByInheritancePolymorphismNew.MyBaseClase();
            BaseClassObjectMemoryUsage = GC.GetTotalMemory(true);
            ByInheritancePolymorphismNew.MyDerivedClass fooInheritancePolymorphismNewMyDerivedClassObject = new ByInheritancePolymorphismNew.MyDerivedClass();
            DerivedClassObjectMemoryUsage = GC.GetTotalMemory(true);

            var foo1 = (ByInheritancePolymorphismOverride.MyBaseClase)fooInheritancePolymorphismMyDerivedClassObject;

            Console.WriteLine("量測繼承與多型隱藏之物件使用記憶體使用情況");
            Console.WriteLine($"產生空類別  之執行個體耗用記憶體 : {EmptyClassObjectMemoryUsage - BeginMemoryUsage} ");
            Console.WriteLine($"建立基底類別之執行個體耗用記憶體 : {BaseClassObjectMemoryUsage - EmptyClassObjectMemoryUsage} ");
            Console.WriteLine($"建立衍生類別之執行個體耗用記憶體 : {DerivedClassObjectMemoryUsage - BaseClassObjectMemoryUsage} ");
            Console.WriteLine($"衍生類別之執行個體 與 基底類別之執行個體 記憶體相差數量 : " +
                $"{(DerivedClassObjectMemoryUsage - BaseClassObjectMemoryUsage)- (BaseClassObjectMemoryUsage - EmptyClassObjectMemoryUsage)} ");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
            #endregion

        }
    }
}
