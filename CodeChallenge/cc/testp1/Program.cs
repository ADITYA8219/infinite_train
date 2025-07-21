using System;

class Program
{
    static string RemChar(string inp, int pos)
    {
        if (pos < 0 || pos >= inp.Length)
        {
            return "Invalid position";
        }

        return inp.Substring(0, pos) + inp.Substring(pos + 1);
    }

    static void Main()
    {
        Console.Write("Enter any line ");
        string inp = Console.ReadLine();

        Console.Write("which the position which u wanna remove (0 to " + (inp.Length - 1) + "): ");
        int pos;

        bool isValid = int.TryParse(Console.ReadLine(), out pos);

        if (!isValid || pos < 0 || pos >= inp.Length)
        {
            Console.WriteLine("Invalid position.");
        }
        else
        {
            string result = RemChar(inp, pos);
            Console.WriteLine("Result: " + result);
            Console.Read();
        }
    }
}
