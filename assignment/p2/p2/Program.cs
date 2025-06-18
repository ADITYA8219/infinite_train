using System;

class Program
{
    static void Main()
    {
        Console.Write("enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        if (num >= 0)
            Console.WriteLine($"{num} is a positive number");
        else
            Console.WriteLine($"{num} is a negative number");
    }
}
