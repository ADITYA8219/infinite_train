<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BankSimulation
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Let's Play Bank ---");

        BankAccount myPersonalAccount = null;

        try
        {
            myPersonalAccount = new BankAccount(98765, "Jane Doe", "Checking", 1500.00);
            myPersonalAccount.ShowAllAccountInfo();

            myPersonalAccount.AddMoney(750.00);

            myPersonalAccount.TakeMoneyOut(300.00);

            Console.WriteLine("\nTrying to take out more than you have...");
            myPersonalAccount.TakeMoneyOut(3000.00);
        }
        catch (NotEnoughFundsException problem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Transaction Failed: {problem.Message}");
            Console.ResetColor();
        }
        catch (ArgumentException problem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Input Error: {problem.Message}");
            Console.ResetColor();
        }
        catch (Exception problem)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"An unexpected problem happened: {problem.Message}");
            Console.ResetColor();
        }
        finally
        {
            Console.WriteLine("\n--- End of this transaction attempt ---");
            if (myPersonalAccount != null)
            {
                Console.WriteLine($"Final Amount for Account {myPersonalAccount.AccountIdentifier}: {myPersonalAccount.GetCurrentBalance():C}");
            }
        }

        Console.WriteLine("\nShowing other input issues:");
        try
        {
            BankAccount dodgyAccount = new BankAccount(12346, "Mystery Person", "Savings", -10.00);
        }
        catch (ArgumentException problem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Account Setup Problem: {problem.Message}");
            Console.ResetColor();
        }

        try
        {
            myPersonalAccount.AddMoney(-50.00);
        }
        catch (ArgumentException problem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Deposit Problem: {problem.Message}");
            Console.ResetColor();
        }

        Console.ReadKey();
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BankSimulation
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Let's Play Bank ---");

        BankAccount myPersonalAccount = null;

        try
        {
            myPersonalAccount = new BankAccount(98765, "Jane Doe", "Checking", 1500.00);
            myPersonalAccount.ShowAllAccountInfo();

            myPersonalAccount.AddMoney(750.00);

            myPersonalAccount.TakeMoneyOut(300.00);

            Console.WriteLine("\nTrying to take out more than you have...");
            myPersonalAccount.TakeMoneyOut(3000.00);
        }
        catch (NotEnoughFundsException problem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Transaction Failed: {problem.Message}");
            Console.ResetColor();
        }
        catch (ArgumentException problem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Input Error: {problem.Message}");
            Console.ResetColor();
        }
        catch (Exception problem)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"An unexpected problem happened: {problem.Message}");
            Console.ResetColor();
        }
        finally
        {
            Console.WriteLine("\n--- End of this transaction attempt ---");
            if (myPersonalAccount != null)
            {
                Console.WriteLine($"Final Amount for Account {myPersonalAccount.AccountIdentifier}: {myPersonalAccount.GetCurrentBalance():C}");
            }
        }

        Console.WriteLine("\nShowing other input issues:");
        try
        {
            BankAccount dodgyAccount = new BankAccount(12346, "Mystery Person", "Savings", -10.00);
        }
        catch (ArgumentException problem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Account Setup Problem: {problem.Message}");
            Console.ResetColor();
        }

        try
        {
            myPersonalAccount.AddMoney(-50.00);
        }
        catch (ArgumentException problem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Deposit Problem: {problem.Message}");
            Console.ResetColor();
        }

        Console.ReadKey();
    }
}
>>>>>>> 68a266f (sqlassignment)
