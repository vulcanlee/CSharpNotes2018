using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    public interface IDriver
    {
        void StartEngine();
        void Drive();
        void StopEngine();
    }
    public interface IMechanic
    {
        void ChangeEngine();
    }
    public class Driver : IDriver
    {
        public void Drive()
        { throw new NotImplementedException(); }

        public void StartEngine()
        { throw new NotImplementedException(); }

        public void StopEngine()
        { throw new NotImplementedException(); }
    }
    public class Mechanic : IMechanic
    {
        public void ChangeEngine()
        { throw new NotImplementedException(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
