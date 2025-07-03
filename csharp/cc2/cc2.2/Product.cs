using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc2._2
{
    public class Product
    {
        public int prodNumber { get; private set; }
        public string prodName { get; private set; }
        public double prodPrice { get; private set; }

        public Product(int id, string name, double price)
        {
            prodNumber = id;
            prodName = name;
            prodPrice = price;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {prodNumber}, Name: {prodName}, Price: {prodPrice:C}");
        }
    }
}
