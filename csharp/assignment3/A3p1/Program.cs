<<<<<<< HEAD
﻿using System;

class Account
{
    public int AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public string AccountCategory { get; set; }
    public char TransactionCode { get; set; }
    public int TransactionAmount { get; set; }
    public int CurrentBalance { get; private set; }

    public Account(int accNumber, string custName, string accCategory, int startingBalance = 0)
    {
        AccountNumber = accNumber;
        CustomerName = custName;
        AccountCategory = accCategory;
        CurrentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        CurrentBalance += amount;
    }

    public void Withdraw(int amount)
    {
        if (amount <= CurrentBalance)
        {
            CurrentBalance -= amount;
        }
        else
        {
            Console.WriteLine("u r broke.");
        }
    }

    public void ProcessTransaction(char transType, int amount)
    {
        TransactionCode = char.ToUpper(transType);
        TransactionAmount = amount;

        if (TransactionCode == 'D')
            Deposit(amount);
        else if (TransactionCode == 'W')
            Withdraw(amount);
        else
            Console.WriteLine("Invalid transaction type.");
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Account Number: " + AccountNumber);
        Console.WriteLine("Customer Name: " + CustomerName);
        Console.WriteLine("Account Type: " + AccountCategory);
        Console.WriteLine("Transaction Type: " + TransactionCode);
        Console.WriteLine("Transaction Amount: ₹" + TransactionAmount);
        Console.WriteLine("Balance: ₹" + CurrentBalance);
    }
}

class Program
{
    static void Main()
    {
        Account myAccount = new Account(71234, "virat", "Checking", 2838);

        myAccount.ProcessTransaction('D', 823);
        myAccount.DisplayDetails();

        Console.WriteLine();

        myAccount.ProcessTransaction('W', 938);
        myAccount.DisplayDetails();
        Console.Read();
    }
}
=======
﻿using System;

class Account
{
    public int AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public string AccountCategory { get; set; }
    public char TransactionCode { get; set; }
    public int TransactionAmount { get; set; }
    public int CurrentBalance { get; private set; }

    public Account(int accNumber, string custName, string accCategory, int startingBalance = 0)
    {
        AccountNumber = accNumber;
        CustomerName = custName;
        AccountCategory = accCategory;
        CurrentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        CurrentBalance += amount;
    }

    public void Withdraw(int amount)
    {
        if (amount <= CurrentBalance)
        {
            CurrentBalance -= amount;
        }
        else
        {
            Console.WriteLine("u r broke.");
        }
    }

    public void ProcessTransaction(char transType, int amount)
    {
        TransactionCode = char.ToUpper(transType);
        TransactionAmount = amount;

        if (TransactionCode == 'D')
            Deposit(amount);
        else if (TransactionCode == 'W')
            Withdraw(amount);
        else
            Console.WriteLine("Invalid transaction type.");
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Account Number: " + AccountNumber);
        Console.WriteLine("Customer Name: " + CustomerName);
        Console.WriteLine("Account Type: " + AccountCategory);
        Console.WriteLine("Transaction Type: " + TransactionCode);
        Console.WriteLine("Transaction Amount: ₹" + TransactionAmount);
        Console.WriteLine("Balance: ₹" + CurrentBalance);
    }
}

class Program
{
    static void Main()
    {
        Account myAccount = new Account(71234, "virat", "Checking", 2838);

        myAccount.ProcessTransaction('D', 823);
        myAccount.DisplayDetails();

        Console.WriteLine();

        myAccount.ProcessTransaction('W', 938);
        myAccount.DisplayDetails();
        Console.Read();
    }
}
>>>>>>> 68a266f (sqlassignment)
