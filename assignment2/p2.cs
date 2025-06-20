using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2p2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter any number u want");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} {0} {0} {0}",num);
            Console.WriteLine("{0}{0}{0}{0}",num);
            Console.WriteLine("{0} {0} {0} {0}", num);
            Console.WriteLine("{0}{0}{0}{0}", num);
            Console.Read();

        }
    }
}
