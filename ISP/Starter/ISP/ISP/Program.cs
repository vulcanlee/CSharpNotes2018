using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    public interface IAllInOneCar
    {
        void StartEngine();
        void Drive();
        void StopEngine();
        void ChangeEngine();
    }
    public class Driver : IAllInOneCar
    {
        public void ChangeEngine()
        { throw new NotImplementedException(); }

        public void Drive()
        { throw new NotImplementedException(); }

        public void StartEngine()
        { throw new NotImplementedException(); }

        public void StopEngine()
        { throw new NotImplementedException(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
