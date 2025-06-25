using System;

class Program
{
    static int thelargest(int a, int b, int c)
    {
        int largest = a;

        if (b > largest)
            largest = b;

        if (c > largest)
            largest = c;

        return largest;
    }

    static void Main()
    {
        Console.Write("Enter first number: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.Write("second ");
        int num2 = int.Parse(Console.ReadLine());

        Console.Write("third");
        int num3 = int.Parse(Console.ReadLine());

        int largest = thelargest(num1, num2, num3);
        Console.WriteLine("Largest number is " + largest);
        Console.Read();
    }
}
