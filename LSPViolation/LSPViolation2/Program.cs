using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPViolation2
{
    public interface I鴨子
    {
        void 游泳();
    }
    public class 鴨子 : I鴨子
    {
        public void 游泳() { Console.WriteLine("鴨子正在游泳"); }
    }
    public class 玩具鴨 : I鴨子
    {
        private bool 是否已經開機;

        public void 游泳()
        {
            if (!是否已經開機)
                return;
            Console.WriteLine("玩具鴨正在游泳");
        }
        public void 開機()
        {
            是否已經開機 = true;
            Console.WriteLine("玩具鴨開機了");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<I鴨子> 鴨子集合 = 取得所有鴨子();
            foreach (var item in 鴨子集合)
            {
                開始游泳(item);
            }

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
        static List<I鴨子> 取得所有鴨子()
        {
            return new List<I鴨子>()
            {
                new 鴨子(),
                new 玩具鴨()
            };
        }
        static void 開始游泳(I鴨子 p鴨子)
        {
            if (p鴨子.GetType() == typeof(鴨子))
            {
                p鴨子.游泳();
            }
            else if (p鴨子.GetType() == typeof(玩具鴨))
            {
                (p鴨子 as 玩具鴨).開機();
                p鴨子.游泳();
            }
            else
            {
                throw new Exception("不是一個鴨子");
            }
        }
    }
}
