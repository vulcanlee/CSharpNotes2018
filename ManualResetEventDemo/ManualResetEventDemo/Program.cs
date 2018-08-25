using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManualResetEventDemo
{
    class Program
    {
        // 等候通知便結束程式執行
        static AutoResetEvent WaitForExitProgram = new AutoResetEvent(false);
        // 等候通知，便開始進行比賽
        static ManualResetEvent WaitForGameStart = new ManualResetEvent(false);

        // 定義隨機亂數用於測試之用
        static Random 隨機亂數 = new Random();

        static void Main()
        {
            // 使用 ThreadPool.QueueUserWorkItem 產生5個執行緒
            Console.WriteLine("開始比賽前的比賽準備");
            for (int i = 1; i <= 5; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(進行比賽), i);
            }
            Console.WriteLine("等候裁判通知，比賽就會開始");


            ThreadPool.QueueUserWorkItem((x) =>
            {
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.B)
                    {
                        WaitForGameStart.Set();
                    }
                    if (key.Key == ConsoleKey.Q)
                    {
                        WaitForExitProgram.Set();
                    }
                }
            });

            Console.WriteLine("等候通知，該程式就會結束執行");
            WaitForExitProgram.WaitOne();
        }

        static void 進行比賽(Object state)
        {
            // 向等候的執行緒通知發生事件
            int are = (int)state;
            int time = 1000 * 隨機亂數.Next(2, 5);
            Console.WriteLine($"參賽者 {are} 需要 {time} 毫秒的時間來準備");
            Thread.Sleep(time);
            Console.WriteLine($"參賽者 {are} 準備好了");
            // 設定作業已經成功
            WaitForGameStart.WaitOne();
            Console.WriteLine($"參賽者 {are} 開始進行比賽");
            time = 1000 * 隨機亂數.Next(5, 10);
            Thread.Sleep(time);
            Console.WriteLine($"參賽者 {are} 抵達終點");
        }
    }
}
