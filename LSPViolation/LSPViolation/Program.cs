using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPViolation
{
    #region Example1
    class 鳥
    {
        public virtual void fly() { Console.WriteLine("鳥在飛"); }
        public virtual void eat() { Console.WriteLine("鳥在吃"); }
    }
    class 老鷹 : 鳥
    {
        public override void fly() { Console.WriteLine("老鷹在飛"); }
        public override void eat() { Console.WriteLine("老鷹在吃"); }
    }
    class 鴕鳥 : 鳥
    {
        public override void fly() { throw new NotSupportedException("鴕鳥不能飛"); }
        public override void eat() { Console.WriteLine("老鷹在吃"); }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            List<鳥> birds = new List<鳥>();
            birds.Add(new 鳥());
            birds.Add(new 老鷹());
            birds.Add(new 鴕鳥());
            BirdsFly(birds);
        }
        static void BirdsFly(List<鳥> birdList)
        {
            foreach (var item in birdList)
            {
                item.fly();
            }
        }
    }
}
