using System;

namespace WithoutDIP
{
    class Program
    {
        static void Main(string[] args)
        {
            Copy();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

        }

        private static void Copy()
        {
            while(true)
            {
                var pressKey = Console.ReadKey(true);
                if(pressKey.Key == ConsoleKey.Escape)
                {
                    return;
                }
                Console.Write(pressKey.KeyChar);
            }
        }
    }
}
