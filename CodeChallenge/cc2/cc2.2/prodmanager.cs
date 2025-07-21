using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc2._2
{
    public class ProductManager
    {
        public static void Main(string[] args)
        {
            List<Product> ProductList = new List<Product>();
            int n = 3;

            Console.WriteLine($"enter details for {n} products:");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n Product {i + 1}");
                
                    Console.Write("Enter Item Number: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Item Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Item Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Product newProd = new Product(id, name, price);
                    ProductList.Add(newProd);
                }
                
            

            Console.WriteLine("\n Products Before Sorting ");
            foreach (Product product in ProductList)
            {
                product.ShowInfo();
            }

           
            List<Product> sortedProducts = ProductList.OrderBy(p => p.prodPrice).ToList();

            Console.WriteLine("\nProducts Sorted by Price ");
            foreach (Product product in sortedProducts)
            {
                product.ShowInfo();
            }

            Console.ReadKey();
        }
    }
}
