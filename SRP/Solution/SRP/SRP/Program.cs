using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    public class Product { }
    public class Customer { }
    public class Stock
    {
        public void CheckAvailability(IEnumerable<Product> products) { }
    }
    public class Payment
    {
        public void Processing(Customer customer, 
            IEnumerable<Product> products) { }
    }
    public class Shipment
    {
        public void SendProducts(Customer customer, 
            IEnumerable<Product> products) { }
    }
    public class OrderManager
    {
        public List<Product> Products = new List<Product>();
        public Customer Customer { get; set; }
        public OrderManager()
        {

        }
        public void Processing()
        {
            new Stock().CheckAvailability(Products);
            new Payment().Processing(Customer, Products);
            new Shipment().SendProducts(Customer, Products);
        }
    }

    public


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
