using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP
{
    public class SecurityService
    {
        public bool LoginUser(string userName, string password)
        {
            LoginService service = new LoginService();
            return service.ValidateUser(userName, password);
        }
    }
    public class LoginService
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
