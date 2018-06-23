using System;
using System.IO;

namespace WithoutDIP2File
{
    public class ToFile
    {
        private static StreamWriter _streamWriter;

        public static void Initialize(string path)
        {
            _streamWriter = new StreamWriter(path);
        }

        public static void Write(char character)
        {
            _streamWriter.Write(character);
        }

        public static void Dispose()
        {
            _streamWriter.Close();
            _streamWriter = null;
        }
    }

    public enum Target
    {
        Console,
        File
    }
    class Program
    {
        static void Main(string[] args)
        {
            Copy(Target.File);

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

        }

        private static void Copy(Target target)
        {
            if (target == Target.File)
                ToFile.Initialize("output.txt");

            while (true)
            {
                var pressKey = Console.ReadKey(true);
                if (pressKey.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (target == Target.Console)
                {
                    Console.Write(pressKey.KeyChar);
                }
                else
                {
                    ToFile.Write(pressKey.KeyChar);
                }
            }

            if(target == Target.File)
            {
                ToFile.Dispose();
            }
        }
    }
}
