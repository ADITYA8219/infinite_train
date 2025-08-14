using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringp2
{
    class Program
    {
        static void Main(string[] args)
        {
            
                Console.Write("Enter a word: ");
                string word = Console.ReadLine();

                int length = word.Length;

            char[] ch = word.ToCharArray();
            Array.Reverse(ch);
            string rev = new string(ch);

                Console.WriteLine("The rev word is: " + rev);
            Console.Read();
            }
        }

    }

