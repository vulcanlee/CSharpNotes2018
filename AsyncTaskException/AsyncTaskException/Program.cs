using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTaskException
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region 在執行非同步方法前發生例外異常
            //try
            //{
            //    Task<string> task1 = GetContentAsync(null);
            //    var content = await task1;
            //}
            //catch (Exception exceptionSync)
            //{
            //    Console.WriteLine(exceptionSync.Message);
            //}
            #endregion

            #region 在執行非同步方法時發生例外異常
            Task<string> task2 = null;
            try
            {
                task2 = GetContentAsync("https://www.google.com");
                var content = await task2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion


            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

        }

        static Task<string> GetContentAsync(string url)
        {
            if (url == null)
                throw new ArgumentException($"{nameof(url)} 為空值");

            return GetContentInternalAsync(url);
        }

        static async Task<string> GetContentInternalAsync(string url)
        {
            var content = await new HttpClient().GetStringAsync(url);
            throw new HttpRequestException("模擬存取網路異常");
            return content;
        }
    }
}
