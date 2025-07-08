using System;
using System.IO;

public class LineCounter
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the path of the file you want to count lines for: ");
        string filePath = Console.ReadLine();

        try
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                int lineCount = lines.Length;
                Console.WriteLine($"The file '{filePath}' has {lineCount} lines.");
            }
            else
            {
                Console.WriteLine($"Error: The file '{filePath}' does not exist.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file '{filePath}' was not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Error: You do not have permission to access the file '{filePath}'.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An I/O error occurred while reading the file: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}