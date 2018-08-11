using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncVoid
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncVoidException_Capture();
        }

        private static void AsyncVoidException_Capture()
        {
            try
            {
                ThrowExcpetionAsync();
            }
            catch (Exception ex)
            {
                // 這裡無法捕捉到例外異常
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static async void ThrowExcpetionAsync()
        {
            throw new Exception("Async Void Exception");
        }
    }
}
