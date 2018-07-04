using System;
using System.Collections.Generic;
using System.Drawing;

namespace RefactorSwitchDictionary
{
    public class StringToColor
    {
        public Color Transfer(string name)
        {
            Color transferResult;

            switch (name.ToLower())
            {
                case "red":
                    transferResult = Color.FromArgb(0xFF, 0xFF, 0x00, 0x00);
                    break;
                case "green":
                    transferResult = Color.FromArgb(0xFF, 0x80, 0x80, 0x80);
                    break;
                case "blue":
                    transferResult = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF);
                    break;
                default:
                    throw new ArgumentException("不正確的顏色名稱");
            }
            return transferResult;
        }
    }

    namespace RefactorSwitchDictionary.Refactoring
    {
        public class StringToColor
        {
            Dictionary<string, Color> ColorMaps;
            public StringToColor()
            {
                ColorMaps = new Dictionary<string, Color>()
                {
                    {"Red",  Color.FromArgb(0xFF, 0xFF, 0x00, 0x00)},
                    {"Green",  Color.FromArgb(0xFF, 0x80, 0x80, 0x80) },
                    {"Blue",  Color.FromArgb(0xFF, 0x00, 0x00, 0xFF)}
                };
            }
            public Color Transfer(string name)
            {
                if(!ColorMaps.ContainsKey(name))
                    throw new ArgumentException("不正確的顏色名稱");
                return ColorMaps[name];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        { 
            string MyColorName = "Blue";

            Console.WriteLine("使用 Swith 來設計方法");

            StringToColor foo = new StringToColor();
            Color fooColor = foo.Transfer(MyColorName);

            Console.WriteLine($"{MyColorName} =  A:{fooColor.A} R:{fooColor.R} G:{fooColor.G} B:{fooColor.B}");
            Console.WriteLine("Press any key for continuing...");

            Console.WriteLine("使用 資料字典 來重構方法，進行 Swith 需求設計");

            RefactorSwitchDictionary.Refactoring.StringToColor fooRefactoring = new RefactorSwitchDictionary.Refactoring.StringToColor();
            Color fooRefactoringColor = fooRefactoring.Transfer(MyColorName);

            Console.WriteLine($"{MyColorName} =  A:{fooRefactoringColor.A} R:{fooRefactoringColor.R} G:{fooRefactoringColor.G} B:{fooRefactoringColor.B}");
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
