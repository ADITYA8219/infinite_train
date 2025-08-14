<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;

public class WordFilter
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter words one by one. Type 'DONE' and press Enter when you're finished.");

        List<string> wordsEnteredByUser = new List<string>();
        string userInput;

        do
        {
            Console.Write("Enter word: ");
            userInput = Console.ReadLine();
            if (userInput.ToUpper() != "DONE")
            {
                wordsEnteredByUser.Add(userInput);
            }
        } while (userInput.ToUpper() != "DONE");

        var filteredWords = wordsEnteredByUser
            .Where(word => word.StartsWith("a", StringComparison.OrdinalIgnoreCase) &&
                           word.EndsWith("m", StringComparison.OrdinalIgnoreCase))
            .ToList();

        Console.WriteLine("\nWords starting with 'a' and ending with 'm':");

        if (filteredWords.Any())
        {
            foreach (string word in filteredWords)
            {
                Console.WriteLine(word);
            }
        }
        else
        {
            Console.WriteLine("No words found matching the criteria.");
        }

      
        Console.ReadKey();
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;

public class WordFilter
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter words one by one. Type 'DONE' and press Enter when you're finished.");

        List<string> wordsEnteredByUser = new List<string>();
        string userInput;

        do
        {
            Console.Write("Enter word: ");
            userInput = Console.ReadLine();
            if (userInput.ToUpper() != "DONE")
            {
                wordsEnteredByUser.Add(userInput);
            }
        } while (userInput.ToUpper() != "DONE");

        var filteredWords = wordsEnteredByUser
            .Where(word => word.StartsWith("a", StringComparison.OrdinalIgnoreCase) &&
                           word.EndsWith("m", StringComparison.OrdinalIgnoreCase))
            .ToList();

        Console.WriteLine("\nWords starting with 'a' and ending with 'm':");

        if (filteredWords.Any())
        {
            foreach (string word in filteredWords)
            {
                Console.WriteLine(word);
            }
        }
        else
        {
            Console.WriteLine("No words found matching the criteria.");
        }

      
        Console.ReadKey();
    }
>>>>>>> 68a266f (sqlassignment)
}