using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskRunException
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //GenerateEmptyThreads();
            try
            {
                Console.WriteLine($"主執行緒 ID : {Thread.CurrentThread.ManagedThreadId} ");
                await MethodAsync("New Exception");
                //await MethodAsync("TaskCompletionSource.SetException");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"完成非同步工作，返回的執行緒 ID : {Thread.CurrentThread.ManagedThreadId} ");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }

        private static void GenerateEmptyThreads()
        {
            ThreadPool.QueueUserWorkItem((x) =>
            {
                Thread.Sleep(200);
            });
            ThreadPool.QueueUserWorkItem((x) =>
            {
                Thread.Sleep(1200);
            });
        }

        static Task MethodAsync(string generateExceptionAction)
        {
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();

            Task.Run(() =>
            {
                Console.WriteLine($"進入 Task.Run 方法內的 執行緒 ID : {Thread.CurrentThread.ManagedThreadId} ");

                Thread.Sleep(1000);
                if (generateExceptionAction == "New Exception")
                    throw new Exception("直接拋出 例外異常");
                if (generateExceptionAction == "TaskCompletionSource.SetException")
                    tcs.SetException(new Exception("藉由SetException 產生例外異常"));
            });
            return tcs.Task;
        }
    }
}
