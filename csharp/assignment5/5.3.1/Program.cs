<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ReadingMaterial
{
    public string TitleOfBook { get; private set; }
    public string WriterName { get; private set; }

    public ReadingMaterial(string bookTitle, string author)
    {
        if (string.IsNullOrWhiteSpace(bookTitle))
        {
            throw new ArgumentException("Book title can't be empty.", nameof(bookTitle));
        }
        if (string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentException("Author's name can't be empty.", nameof(author));
        }

        TitleOfBook = bookTitle;
        WriterName = author;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"  Title: \"{TitleOfBook}\", Author: {WriterName}");
    }
}

public class LiteraryCollection
{
    private ReadingMaterial[] booksInShelf;

    public LiteraryCollection(int shelfCapacity)
    {
        if (shelfCapacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(shelfCapacity), "Shelf capacity must be a positive number.");
        }
        booksInShelf = new ReadingMaterial[shelfCapacity];
    }

    public ReadingMaterial this[int indexPosition]
    {
        get
        {
            if (indexPosition >= 0 && indexPosition < booksInShelf.Length)
            {
                return booksInShelf[indexPosition];
            }
            else
            {
                throw new IndexOutOfRangeException("That shelf spot doesn't exist. Check the index.");
            }
        }
        set
        {
            if (indexPosition >= 0 && indexPosition < booksInShelf.Length)
            {
                booksInShelf[indexPosition] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Can't put a book there. That shelf spot is out of bounds.");
            }
        }
    }

    public void DisplayAllBooksOnShelf()
    {
        Console.WriteLine("\n--- Books on the Shelf ---");
        bool anyBookPresent = false;
        for (int i = 0; i < booksInShelf.Length; i++)
        {
            if (booksInShelf[i] != null)
            {
                Console.Write($"Shelf Spot [{i}]: ");
                booksInShelf[i].ShowDetails();
                anyBookPresent = true;
            }
            else
            {
                Console.WriteLine($"Shelf Spot [{i}]: Empty");
            }
        }
        if (!anyBookPresent)
        {
            Console.WriteLine("The shelf is completely empty right now.");
        }
        Console.WriteLine("--------------------------");
    }
}

public class LibraryExhibit
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Setting up a new book collection...\n");

        LiteraryCollection myStudyShelf = new LiteraryCollection(5);

        Console.WriteLine("Placing books on the shelf:");
        try
        {
            myStudyShelf[0] = new ReadingMaterial("The Silent Patient", "Alex Michaelides");
            myStudyShelf[1] = new ReadingMaterial("Where the Crawdads Sing", "Delia Owens");
            myStudyShelf[2] = new ReadingMaterial("Project Hail Mary", "Andy Weir");
            myStudyShelf[3] = new ReadingMaterial("Atomic Habits", "James Clear");
            myStudyShelf[4] = new ReadingMaterial("The Midnight Library", "Matt Haig");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Problem adding book: {ex.Message}");
            Console.ResetColor();
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Problem creating book: {ex.Message}");
            Console.ResetColor();
        }

        myStudyShelf.DisplayAllBooksOnShelf();

        Console.WriteLine("\nRetrieving a specific book:");
        try
        {
            ReadingMaterial favoriteRead = myStudyShelf[2];
            Console.Write("Your favorite book is: ");
            favoriteRead.ShowDetails();
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Problem retrieving book: {ex.Message}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"An unexpected issue occurred: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\n--- Demo Complete ---");
        Console.ReadKey();
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ReadingMaterial
{
    public string TitleOfBook { get; private set; }
    public string WriterName { get; private set; }

    public ReadingMaterial(string bookTitle, string author)
    {
        if (string.IsNullOrWhiteSpace(bookTitle))
        {
            throw new ArgumentException("Book title can't be empty.", nameof(bookTitle));
        }
        if (string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentException("Author's name can't be empty.", nameof(author));
        }

        TitleOfBook = bookTitle;
        WriterName = author;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"  Title: \"{TitleOfBook}\", Author: {WriterName}");
    }
}

public class LiteraryCollection
{
    private ReadingMaterial[] booksInShelf;

    public LiteraryCollection(int shelfCapacity)
    {
        if (shelfCapacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(shelfCapacity), "Shelf capacity must be a positive number.");
        }
        booksInShelf = new ReadingMaterial[shelfCapacity];
    }

    public ReadingMaterial this[int indexPosition]
    {
        get
        {
            if (indexPosition >= 0 && indexPosition < booksInShelf.Length)
            {
                return booksInShelf[indexPosition];
            }
            else
            {
                throw new IndexOutOfRangeException("That shelf spot doesn't exist. Check the index.");
            }
        }
        set
        {
            if (indexPosition >= 0 && indexPosition < booksInShelf.Length)
            {
                booksInShelf[indexPosition] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Can't put a book there. That shelf spot is out of bounds.");
            }
        }
    }

    public void DisplayAllBooksOnShelf()
    {
        Console.WriteLine("\n--- Books on the Shelf ---");
        bool anyBookPresent = false;
        for (int i = 0; i < booksInShelf.Length; i++)
        {
            if (booksInShelf[i] != null)
            {
                Console.Write($"Shelf Spot [{i}]: ");
                booksInShelf[i].ShowDetails();
                anyBookPresent = true;
            }
            else
            {
                Console.WriteLine($"Shelf Spot [{i}]: Empty");
            }
        }
        if (!anyBookPresent)
        {
            Console.WriteLine("The shelf is completely empty right now.");
        }
        Console.WriteLine("--------------------------");
    }
}

public class LibraryExhibit
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Setting up a new book collection...\n");

        LiteraryCollection myStudyShelf = new LiteraryCollection(5);

        Console.WriteLine("Placing books on the shelf:");
        try
        {
            myStudyShelf[0] = new ReadingMaterial("The Silent Patient", "Alex Michaelides");
            myStudyShelf[1] = new ReadingMaterial("Where the Crawdads Sing", "Delia Owens");
            myStudyShelf[2] = new ReadingMaterial("Project Hail Mary", "Andy Weir");
            myStudyShelf[3] = new ReadingMaterial("Atomic Habits", "James Clear");
            myStudyShelf[4] = new ReadingMaterial("The Midnight Library", "Matt Haig");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Problem adding book: {ex.Message}");
            Console.ResetColor();
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Problem creating book: {ex.Message}");
            Console.ResetColor();
        }

        myStudyShelf.DisplayAllBooksOnShelf();

        Console.WriteLine("\nRetrieving a specific book:");
        try
        {
            ReadingMaterial favoriteRead = myStudyShelf[2];
            Console.Write("Your favorite book is: ");
            favoriteRead.ShowDetails();
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Problem retrieving book: {ex.Message}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"An unexpected issue occurred: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\n--- Demo Complete ---");
        Console.ReadKey();
    }
}
>>>>>>> 68a266f (sqlassignment)
