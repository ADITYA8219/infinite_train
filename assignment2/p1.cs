using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2p1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1, n2;
            Console.WriteLine("enter first num");
            n1=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter sec num");
            n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"before swap:n1={n1}and n2={n2}");

            n1 = n1 ^ n2;
            n2 = n1 ^ n2;
            n1 = n1 ^ n2;
            Console.WriteLine($"after swapping n1={n1}and n2={n2}");
            Console.Read();



        }
    }
}
