using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc2._3
{
    public class NumberValidator
    {
        public static void CheckNegative(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "It's Negative");
            }
            Console.WriteLine($"great {n}. It's not negative.");
        }

        public static void Main(string[] args)
        {
            Console.Write("\nEnter a number to check  ");
            string input = Console.ReadLine();
            int num;

            try
            {
                num = int.Parse(input);
                CheckNegative(num);
            }
           
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error Found: {ex.Message}");
            }
           

            Console.Write("\nEnter another number to check ");
            string Input2 = Console.ReadLine();
            int num2;

            try
            {
                num2 = int.Parse(Input2);
                CheckNegative(num2);
            }
            
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error found: {ex.Message}");
            }
            
            Console.ReadKey();
        }
    }
}