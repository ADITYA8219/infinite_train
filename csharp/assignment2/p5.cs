using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2p4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the size of the array");
            int sz = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[sz];
            for (int i = 0; i < sz; i++)
            {
                Console.Write($"elemnt {i + 1}");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int min = arr.Min();
            int max = arr.Max();
            int avg, sum = 0;
            for (int i = 0; i < sz; i++)
            {
                sum += arr[i];
            }
            avg = sum / 2;
            Console.WriteLine($"average {avg},min {min},max {max},sum {sum}");
            Console.WriteLine("before sorting the elements are like this");
            for(int i = 0; i < sz; i++)
            {
                Console.WriteLine(arr[i]);
            }

            Console.WriteLine("after sorting");
            Array.Sort(arr);
            Console.WriteLine(string.Join(",",arr));
            Array.Reverse(arr);
            Console.WriteLine(string.Join(",",arr));
            Console.Read();
        }
    }
}
