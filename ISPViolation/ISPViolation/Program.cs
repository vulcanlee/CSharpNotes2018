using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPViolation
{
    public interface IBusinessPrinters
    {
        void Scan();
        void Print();
        void Copy();
        void FaxSending();
        void FaxReceiving();
    }
    public class AllInOnePrinter : IBusinessPrinters
    {
        public void Copy() { Console.WriteLine("拷貝中"); }
        public void FaxReceiving() { Console.WriteLine("傳真接收中"); }
        public void FaxSending() { Console.WriteLine("傳真發送中"); }
        public void Print() { Console.WriteLine("列印中"); }
        public void Scan() { Console.WriteLine("掃描中"); }
    }
    public class SimplePrinter : IBusinessPrinters
    {
        public void Copy() { Console.WriteLine("錯誤!! 無此功能"); }
        public void FaxReceiving() { Console.WriteLine("錯誤!! 無此功能"); }
        public void FaxSending() { Console.WriteLine("錯誤!! 無此功能"); }
        public void Print() { Console.WriteLine("列印中"); }
        public void Scan() { Console.WriteLine("錯誤!! 無此功能"); }
    }
    public class CopyPrinter : IBusinessPrinters
    {
        public void Copy() { Console.WriteLine("拷貝中"); }
        public void FaxReceiving() { Console.WriteLine("錯誤!! 無此功能"); }
        public void FaxSending() { Console.WriteLine("錯誤!! 無此功能"); }
        public void Print() { Console.WriteLine("列印中"); }
        public void Scan() { Console.WriteLine("掃描中"); }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
