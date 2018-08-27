using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancel
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region 使用 IsCancellationRequested 來處理工作取消請求
            Console.WriteLine("使用 IsCancellationRequested 來處理工作取消請求");
            CancellationTokenSource ctsIsCancellationRequested = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine($"(IsCancellationRequested)請按下任一按鍵或者等候10秒鐘，該非同步工作就會取消");
                Console.ReadKey();
                ctsIsCancellationRequested.Cancel();
            });
            try
            {
                await MethodIsCancellationRequestedAsync(ctsIsCancellationRequested.Token);
            }
            catch (OperationCanceledException oce)
            {
                Console.WriteLine($"已經捕捉到使用者發出的工作取消例外異常 {oce.Message}");
            }
            Console.WriteLine($"Press any key for continuing...{Environment.NewLine}{Environment.NewLine}");
            Console.ReadKey();
            #endregion

            #region 使用 ThrowIfCancellationRequested 來處理工作取消請求
            CancellationTokenSource ctsThrowIfCancellationRequested = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine($"(ThrowIfCancellationRequested)請按下任一按鍵或者等候10秒鐘，該非同步工作就會取消");
                Console.ReadKey();
                ctsThrowIfCancellationRequested.Cancel();
            });
            try
            {
                await MethodThrowIfCancellationRequestedAsync(ctsThrowIfCancellationRequested.Token);
            }
            catch (OperationCanceledException oce)
            {
                Console.WriteLine($"已經捕捉到使用者發出的工作取消例外異常 {oce.Message}");
            }
            Console.WriteLine($"Press any key for continuing...{Environment.NewLine}{Environment.NewLine}");
            Console.ReadKey();
            #endregion

            #region 使用 Register 事件 來處理工作取消請求
            CancellationTokenSource ctsRegisterCallBack = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine($"(Register 事件)請按下任一按鍵或者等候10秒鐘，該非同步工作就會取消");
                Console.ReadKey();
                ctsRegisterCallBack.Cancel();
            });
            try
            {
                await MethodRegisterCallBackAsync(ctsRegisterCallBack.Token);
            }
            catch (OperationCanceledException oce)
            {
                Console.WriteLine($"已經捕捉到使用者發出的工作取消例外異常 {oce.Message}");
            }
            #endregion

            Console.WriteLine("處理程序 Process 準備結束執行");
            Console.WriteLine($"Press any key for continuing...{Environment.NewLine}{Environment.NewLine}");
            Console.ReadKey();
        }

        private static Task MethodIsCancellationRequestedAsync(CancellationToken token)
        {
            TaskCompletionSource<DateTime> tcs = new TaskCompletionSource<DateTime>();
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(500);
                    Console.Write(".");
                    if (token.IsCancellationRequested == true)
                    {
                        Console.WriteLine($"使用者已經提出取消請求");
                        tcs.SetCanceled();
                        break;
                    }
                }
            });
            return tcs.Task;
        }
        private static Task MethodThrowIfCancellationRequestedAsync(CancellationToken token)
        {
            TaskCompletionSource<DateTime> tcs = new TaskCompletionSource<DateTime>();
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(500);
                    Console.Write(".");
                    #region 不可行的模式
                    //// 當收到 Cancel() 方法呼叫，底下的方法會造成例外異常，整個程式會被凍結
                    //token.ThrowIfCancellationRequested();
                    #endregion

                    try
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    catch
                    {
                        // 底下這行會造成在除錯模式下，該執行緒有例外異常中斷發生
                        tcs.SetCanceled();
                    }
                }
            });
            return tcs.Task;
        }
        private static Task MethodRegisterCallBackAsync(CancellationToken token)
        {
            Thread thread;
            bool isCancle = false;
            TaskCompletionSource<DateTime> tcs = new TaskCompletionSource<DateTime>();
            Task.Run(() =>
            {
                thread = Thread.CurrentThread;
                Console.WriteLine($"非同步執行緒 ID = {Thread.CurrentThread.ManagedThreadId}");
                #region Register不正確的作法
                token.Register(() =>
                { 
                    Console.WriteLine($"Register事件內 執行緒 ID = {Thread.CurrentThread.ManagedThreadId}");
                    // 方法1: 設定要取消旗標為真，讓這個執行緒結束執行
                    isCancle = true;

                    #region 類另做法，啟動另外一個執行緒，終止非同步執行緒。因為當執行 SetCanceled() 方法後，就無法再執行其他敘述了
                    Console.WriteLine($"準備針對非同步工作 執行緒 ID = {thread.ManagedThreadId} 下達終止請求");
                    // 方法2: 啟動另外一個執行緒，下達執行緒終止執行的請求
                    ThreadPool.QueueUserWorkItem(x =>
                    {
                        thread.Abort();
                    });
                    #endregion

                    // 下達這個方法，也只是造成非同步工作完成，但原來執行緒上的工作，卻還是繼續在執行
                    tcs.SetCanceled();
                    // 下達該指令也是無效的，因為，在該事件內與非同步工作內的執行緒 是不同的
                    //Thread.CurrentThread.Abort();
                }, true);
                #endregion
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(500);
                    Console.Write(".");
                    // 方法1: 在這裡判斷要讓這個執行緒結束執行
                    //if (isCancle) break;
                }

            });
            return tcs.Task;
        }


    }
}
