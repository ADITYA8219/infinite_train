using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays_p3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter array size");
            int s = Convert.ToInt32(Console.ReadLine());
            int[] arr1 = new int[s];
            int[] arr2 = new int[s];
            for(int i = 0; i < s; i++)
            {
                arr1[i]=Convert.ToInt32(Console.ReadLine());
            }
            
            for(int i = 0; i < s; i++)
            {
                arr2[i] = arr1[i];
            }
            Console.WriteLine("after copying"); 
            for(int i = 0; i < s; i++)
            {
                Console.WriteLine(arr2[i]);
            }
            Console.Read();


        }
    }
}
