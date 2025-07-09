using System;
using System.IO;

namespace cc3__3
{
    public class FileAppender
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the file name to append to like filename.txt: ");
            string fileName = Console.ReadLine();

            Console.Write("Enter the text to append: ");
            string textToAppend = Console.ReadLine();

            try
            {
                using (StreamWriter fileWriter = new StreamWriter(fileName, true))
                {
                    fileWriter.WriteLine(textToAppend);
                }
                Console.WriteLine($"Successfully appended text to '{fileName}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
