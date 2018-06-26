using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
    public class Rectangle
    {
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public virtual int Area() => Width * Height;
    }

    public class Square : Rectangle
    {
        private int _height;
        private int _width;
        public override int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value; _width = value;
            }
        }
        public override int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value; _height = value;
            }
        }
        public override int Area() => Width * Height;
    }

    public class LSPBehavior
    {
        public static void Method(Rectangle s)
        {
            s.Height = 8;
            s.Width = 7;
            if (s.Area() != 56)
                throw new Exception("不正確的面積");
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            Square square = new Square();
            square.Height = 5;
            LSPBehavior.Method(square);

            Console.WriteLine($"Square Width={square.Width} Height={square.Height}");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
