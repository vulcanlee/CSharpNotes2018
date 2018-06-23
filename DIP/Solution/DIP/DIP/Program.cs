using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP
{
    public class SecurityService
    {
        private readonly ILoginService _LoginService;

        public SecurityService(ILoginService loginService)
        {
            this._LoginService = loginService;
        }
        public bool LoginUser(string userName, string password)
        {
            return _LoginService.ValidateUser(userName, password);
        }
    }
    public interface ILoginService
    {
        bool ValidateUser(string userName, string password);
    }
    public class LoginService : ILoginService
    {
        public bool ValidateUser(string userName, string password)
        { throw new NotImplementedException(); }
    }
    public class GlobalLoginService : ILoginService
    {
        public bool ValidateUser(string userName, string password)
        { throw new NotImplementedException(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
