using System;

class Program
{
    static void Main()
    {
        Console.Write("enter first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("enter operation (+, -, *, /): ");
        char op = Convert.ToChar(Console.ReadLine());

        Console.Write("Input second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        switch (op)
        {
            case '+':
                Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
                break;
            case '-':
                Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
                break;
            case '*':
                Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
                break;
            case '/':
                if (num2 != 0)
                    Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
                else
                    Console.WriteLine("Cannot divide by zero");
                break;
            default:
                Console.WriteLine("Invalid operation");
                break;
        }
    }
}
