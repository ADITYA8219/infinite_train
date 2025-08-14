<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign6_1
{
    public class BookShelf
    {
        private Book[] _books;
        private const int MAX_BOOKS = 5;

        public BookShelf()
        {
            _books = new Book[MAX_BOOKS];
        }

        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < MAX_BOOKS)
                {
                    return _books[index];
                }
                throw new IndexOutOfRangeException("Index is out of the bounds of the BookShelf.");
            }
            set
            {
                if (index >= 0 && index < MAX_BOOKS)
                {
                    _books[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of the bounds of the BookShelf.");
                }
            }
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("\n--- Books on the Shelf ---");
            for (int i = 0; i < MAX_BOOKS; i++)
            {
                if (_books[i] != null)
                {
                    Console.Write($"Book {i + 1}: ");
                    _books[i].Display();
                }
                else
                {
                    Console.WriteLine($"Book {i + 1}: (Empty Slot)");
                }
            }
            Console.WriteLine("--------------------------");
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign6_1
{
    public class BookShelf
    {
        private Book[] _books;
        private const int MAX_BOOKS = 5;

        public BookShelf()
        {
            _books = new Book[MAX_BOOKS];
        }

        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < MAX_BOOKS)
                {
                    return _books[index];
                }
                throw new IndexOutOfRangeException("Index is out of the bounds of the BookShelf.");
            }
            set
            {
                if (index >= 0 && index < MAX_BOOKS)
                {
                    _books[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of the bounds of the BookShelf.");
                }
            }
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("\n--- Books on the Shelf ---");
            for (int i = 0; i < MAX_BOOKS; i++)
            {
                if (_books[i] != null)
                {
                    Console.Write($"Book {i + 1}: ");
                    _books[i].Display();
                }
                else
                {
                    Console.WriteLine($"Book {i + 1}: (Empty Slot)");
                }
            }
            Console.WriteLine("--------------------------");
        }
    }
}
>>>>>>> 68a266f (sqlassignment)
