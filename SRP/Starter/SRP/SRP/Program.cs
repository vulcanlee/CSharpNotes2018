using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class Product { }
    public class Customer { }
    public class OrderManager
    {
        public List<Product> Products = new List<Product>();
        public Customer Customer { get; set; }
        public void Processing()
        {
            // 檢查商品庫存數量是否足夠
            // 進行付款處理程序
            // 進行送貨處理程序
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
