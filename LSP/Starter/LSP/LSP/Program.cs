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
    }

    public class AreaCalculator
    {
        public static int CalculateArea(Rectangle r)
        {
            return r.Height * r.Width;
        }

        public static int CalculateArea(Square s)
        {
            return s.Height * s.Height;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("里氏替換原則 Liskov Substitution Principle");

            var myRectangle = new Rectangle { Height = 2, Width = 3 };
            var result = AreaCalculator.CalculateArea(myRectangle);
            Console.WriteLine($"矩形 {myRectangle.Width} x {myRectangle.Height} = {result}");

            var mySquare = new Square { Height = 3 };
            result = AreaCalculator.CalculateArea(mySquare);
            Console.WriteLine($"正方形 {mySquare.Width} x {mySquare.Height} = {result}");

            Rectangle newRectangle = new Square();
            newRectangle.Height = 4;
            newRectangle.Width = 6;
            result = AreaCalculator.CalculateArea(newRectangle);
            Console.WriteLine($"矩形 {newRectangle.Width} x {newRectangle.Height} = {result}");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

        }
    }
}
