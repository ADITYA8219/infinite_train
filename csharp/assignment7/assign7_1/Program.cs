using System;
using System.Collections.Generic;

public class NumberSquaredFilterTraditional
{
    public static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 7, 2, 30, 4, 10 };

        Console.WriteLine("Numbers and their squares (where square > 20):");

        foreach (int num in numbers)
        {
            int square = num * num;

            if (square > 20)
            {
                Console.WriteLine($"{num} - {square}");
            }
        }

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}