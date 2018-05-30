using System;

namespace AbstractClass
{
    public abstract class Polygon
    {
        public int Side { get; set; }
        public double Length { get; set; }
        public Polygon(int side, double length)
        {
            Side = side;
            Length = length;
        }
        public double GetPerimeter()
        {
            return Side * Length;
        }
        public abstract double GetArea();
    }

    public class Polygon3 : Polygon
    {
        public Polygon3(double length) : base(3, length)
        { }
        public override double GetArea()
        {
            return Length * Length * Math.Sqrt(3) / 4;
        }
    }
    public class Polygon4 : Polygon
    {
        public Polygon4(double length) : base(3, length)
        { }
        public override double GetArea()
        {
            return Length * Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var fooSide3 = new Polygon3(8);
            Console.WriteLine($"正 {fooSide3.Side} 多邊形之週長為 {fooSide3.GetPerimeter()}");
            Console.WriteLine($"正 {fooSide3.Side} 多邊形之面積為 {fooSide3.GetArea()}");

            var fooSide4 = new Polygon4(8);
            Console.WriteLine($"正 {fooSide4.Side} 多邊形之週長為 {fooSide4.GetPerimeter()}");
            Console.WriteLine($"正 {fooSide4.Side} 多邊形之面積為 {fooSide4.GetArea()}");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
