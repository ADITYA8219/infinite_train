<<<<<<< HEAD
﻿using System;
using ConcessionLibrary; 

public class Program
{
    public const decimal TotalFare = 500M; 

    public static void Main(string[] args)
    {
        Console.Write("Enter your Name: ");
        string userName = Console.ReadLine();

        Console.Write("Enter your Age: ");
        int userAge = int.Parse(Console.ReadLine()); 

        ConcessionCalculator calculator = new ConcessionCalculator();
        string concessionMessage = calculator.CalculateConcession(userAge);

        Console.WriteLine($"\nDear {userName}, your travel status:");
        Console.WriteLine(concessionMessage);

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
=======
﻿using System;
using ConcessionLibrary; 

public class Program
{
    public const decimal TotalFare = 500M; 

    public static void Main(string[] args)
    {
        Console.Write("Enter your Name: ");
        string userName = Console.ReadLine();

        Console.Write("Enter your Age: ");
        int userAge = int.Parse(Console.ReadLine()); 

        ConcessionCalculator calculator = new ConcessionCalculator();
        string concessionMessage = calculator.CalculateConcession(userAge);

        Console.WriteLine($"\nDear {userName}, your travel status:");
        Console.WriteLine(concessionMessage);

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
>>>>>>> 68a266f (sqlassignment)
}