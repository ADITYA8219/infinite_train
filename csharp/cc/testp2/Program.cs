using System;

class Program
{
    static string swap(string inp)
    {
        if (inp.Length <= 1)
            return inp;

        char first = inp[0];
        char last = inp[inp.Length - 1];
        string middle = inp.Substring(1, inp.Length - 2);

        return last + middle + first;
    }

    static void Main()
    {
        Console.Write("Enter any string: ");
        string inp = Console.ReadLine();

        string result = swap(inp);
        Console.WriteLine("Result: " + result);
        Console.Read();
    }
}
