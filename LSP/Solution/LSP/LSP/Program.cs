using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
    public abstract class Shape
    {
        public abstract int Area();
        public abstract string Desctiption();
    }

    public class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public override int Area()
        {
            return Height * Width;
        }

        public override string Desctiption()
        {
            return $"矩形 {Width} x {Height}";
        }
    }

    public class Square : Shape
    {
        public int Sides;
        public override int Area()
        {
            return Sides * Sides;
        }

        public override string Desctiption()
        {
            return $"正方形 {Sides} x {Sides}";
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("里氏替換原則 Liskov Substitution Principle");

            Rectangle myRectangle = new Rectangle { Height = 2, Width = 3 };
            var result = myRectangle.Area();
            Console.WriteLine($"{myRectangle.Desctiption()}  = {result}");

            Square mySquare = new Square { Sides = 3 };
            result = mySquare.Area();
            Console.WriteLine($"{mySquare.Desctiption()}  = {result}");

            var shapes = new List<Shape>{
                new Rectangle{Height=4,Width=6},
                new Square{Sides=3}
            };
            var areas = new List<int>();
            foreach (Shape shape in shapes)
            {
                result = shape.Area();
                Console.WriteLine($"{shape.Desctiption()}  = {result}");
            }

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

        }
    }
}
