using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> numbers = new List<int>() { 36, 71, 12, 15, 29, 18, 27, 17, 9, 34 };

        Console.WriteLine("Numbers divisible by 3:");
        int cnt = 0;
        foreach (int number in numbers)
        {
            if (number % 3 == 0)
            {
                Console.WriteLine(number);
            }
        }
      
        Console.Read();
    }
}