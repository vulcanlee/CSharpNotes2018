using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPViolation
{
    class 鳥
    {
        public virtual void 飛() { Console.WriteLine("鳥在飛"); }
        public virtual void 吃() { Console.WriteLine("鳥在吃"); }
    }
    class 老鷹 : 鳥
    {
        public override void 飛() { Console.WriteLine("老鷹在飛"); }
        public override void 吃() { Console.WriteLine("老鷹在吃"); }
    }
    class 鴕鳥 : 鳥
    {
        public override void 飛() { throw new NotSupportedException("鴕鳥不能飛"); }
        public override void 吃() { Console.WriteLine("老鷹在吃"); }
    }
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
                item.飛();
            }
        }
    }
}
