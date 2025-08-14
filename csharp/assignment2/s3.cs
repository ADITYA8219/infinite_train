using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter first word");
            string s1 = Console.ReadLine();

            Console.WriteLine("enter sec word");
            string s2 = Console.ReadLine();

            if (s1 == s2)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("not equal");
            }
            Console.Read();
        }
    }
}
