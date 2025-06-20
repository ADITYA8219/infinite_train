using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2p3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("want to know week day then press any number between 1-7");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Console.WriteLine("its monday");
                    break;
                case 2:
                    Console.WriteLine("its tuesday");
                    break;
                case 3:
                    Console.WriteLine("its wednesday");
                    break;
                case 4:
                    Console.WriteLine("its thursday");
                    break;
                case 5:
                    Console.WriteLine("its friday");
                    break;
                case 6:
                    Console.WriteLine("its saturday");
                    break;
                case 7:
                    Console.WriteLine("hooray...its sunday");
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
            Console.Read();
        }
    }
}
