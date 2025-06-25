using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        int sum = a + b;
        if (a == b)
            Console.WriteLine($"Result: {sum * 3}");
        else
            Console.WriteLine($"Result: {sum}");
    }
}
