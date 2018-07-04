using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RefactorSwitchDelegate
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
        #region 將不同顏色名稱轉換成為顏色物件的過程，設計成為不同的類別
        public abstract class ColorTransfer
        {
            public abstract Color Transfer();
        }
        public class TransferToRed : ColorTransfer
        {
            public override Color Transfer()
            {
                return Color.FromArgb(0xFF, 0xFF, 0x00, 0x00);
            }
        }
        public class TransferToGreen : ColorTransfer
        {
            public override Color Transfer()
            {
                return Color.FromArgb(0xFF, 0x80, 0x80, 0x80);
            }
        }
        public class TransferToBlue : ColorTransfer
        {
            public override Color Transfer()
            {
                return Color.FromArgb(0xFF, 0x00, 0x00, 0xFF);
            }
        }
        public class StringToColor
        {
            Dictionary<string, ColorTransfer> _colorMaps;
            public StringToColor()
            {
                _colorMaps = new Dictionary<string, ColorTransfer>()
                {
                    {"Red", new TransferToRed() },
                    {"Green", new TransferToGreen() },
                    {"Blue", new TransferToBlue() },
                };
            }
            public Color Transfer(string name)
            {
                if (!_colorMaps.ContainsKey(name))
                    throw new ArgumentException("不正確的顏色名稱");
                return _colorMaps[name].Transfer();
            }
        }
        #endregion
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
            Console.ReadKey();

            Console.WriteLine("使用 資料字典與多型 來重構方法，進行 Swith 需求設計");

            RefactorSwitchDictionary.Refactoring.StringToColor fooRefactoring = new RefactorSwitchDictionary.Refactoring.StringToColor();
            Color fooRefactoringColor = fooRefactoring.Transfer(MyColorName);

            Console.WriteLine($"{MyColorName} =  A:{fooRefactoringColor.A} R:{fooRefactoringColor.R} G:{fooRefactoringColor.G} B:{fooRefactoringColor.B}");
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
