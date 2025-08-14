<<<<<<< HEAD
﻿using System;
using System.IO;

public class FileWriteExample
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the file name (e.g., mydata.txt): ");
        string filePath = Console.ReadLine();

        Console.WriteLine("Enter the lines of text. Press Enter after each line. Type 'DONE' on a new line when finished:");

        System.Collections.Generic.List<string> lines = new System.Collections.Generic.List<string>();
        string inputLine;
        do
        {
            inputLine = Console.ReadLine();
            if (inputLine.ToUpper() != "DONE")
            {
                lines.Add(inputLine);
            }
        } while (inputLine.ToUpper() != "DONE");

        try
        {
            File.WriteAllLines(filePath, lines);
            Console.WriteLine($"Successfully wrote {lines.Count} lines to '{filePath}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
=======
﻿using System;
using System.IO;

public class FileWriteExample
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the file name (e.g., mydata.txt): ");
        string filePath = Console.ReadLine();

        Console.WriteLine("Enter the lines of text. Press Enter after each line. Type 'DONE' on a new line when finished:");

        System.Collections.Generic.List<string> lines = new System.Collections.Generic.List<string>();
        string inputLine;
        do
        {
            inputLine = Console.ReadLine();
            if (inputLine.ToUpper() != "DONE")
            {
                lines.Add(inputLine);
            }
        } while (inputLine.ToUpper() != "DONE");

        try
        {
            File.WriteAllLines(filePath, lines);
            Console.WriteLine($"Successfully wrote {lines.Count} lines to '{filePath}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
>>>>>>> 68a266f (sqlassignment)
}