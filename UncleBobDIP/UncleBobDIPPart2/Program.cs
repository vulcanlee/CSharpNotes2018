using System;
using System.IO;


// 這裡將要解決 
// Abstractions should not depend upon details. 
// Details should depend upon abstractions.

namespace UncleBobDIPPart2
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

    public interface IReader
    {
        ReadResult Read();
    }

    public class ReadResult
    {
        public readonly char Character;
        public readonly bool ShouldQuit;

        public ReadResult(char character, bool shouldQuit)
        {
            Character = character;
            ShouldQuit = shouldQuit;
        }
    }

    public class ConsoleReader : IReader
    {
        public ReadResult Read()
        {
            var pressKey= Console.ReadKey(true);
            return new ReadResult(pressKey.KeyChar, pressKey.Key == ConsoleKey.Escape);
        }
    }

    public interface IWriter
    {
        void Write(char character);
    }

    public class ConsoleWriter : IWriter
    {
        public void Write(char character)
        {
            Console.Write(character);
        }
    }

    public class FileWriter : IWriter, IDisposable
    {
        private readonly StreamWriter _streamWriter;
        public FileWriter(string path)
        {
            _streamWriter = new StreamWriter(path);
        }

        public void Dispose()
        {
            _streamWriter.Dispose();
        }

        public void Write(char character)
        {
            _streamWriter.Write(character);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 這裡是 Composition Root，將會在此解決所有相依性需求，在此產生具體實作物件
            var reader = new ConsoleReader();
            //var writer = new ConsoleWriter();
            var writer = new FileWriter("output.txt");

            // 從這裡開始，就是進行您實際程式執行進入點 Entry Pointer
            Copy(reader, writer);

            writer.Dispose();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

        }

        private static void Copy(IReader reader, IWriter writer)
        {
            while (true)
            {
                var readResult = reader.Read();
                if (readResult.ShouldQuit)
                {
                    break;
                }
                writer.Write(readResult.Character);
            }
        }
    }
}
