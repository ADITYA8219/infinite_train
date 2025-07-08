using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign6_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BookShelf myBookShelf = new BookShelf();

            Console.WriteLine("Please enter details for 5 books to add to the bookshelf.");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\nEnter details for Book {i + 1}:");
                Console.Write("Enter Book Name: ");
                string bookName = Console.ReadLine();

                Console.Write("Enter Author Name: ");
                string authorName = Console.ReadLine();

               
                myBookShelf[i] = new Book(bookName, authorName);
            }

            Console.WriteLine("\nDisplaying all books on the bookshelf:");
            myBookShelf.DisplayAllBooks();

           
            Console.WriteLine("\nAccessing the first book directly using indexer:");
            if (myBookShelf[0] != null)
            {
                myBookShelf[0].Display();
            }
        }
    }
}
