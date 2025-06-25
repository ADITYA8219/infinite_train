using System;

class Program
{
    static void Main()
    {
        Console.Write("Input 1st number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input 2nd number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        if (a == b)
            Console.WriteLine($"{a} and {b} are equal");
        else
            Console.WriteLine($"{a} and {b} are not equal");
    }
}
