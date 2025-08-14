<<<<<<< HEAD
﻿using System;
public class BankAccount
{
    public int AccountIdentifier { get; private set; }
    public string OwnerName { get; private set; }
    public string AccountKind { get; private set; }
    public double CurrentBalance { get; private set; }

    public BankAccount(int accountID, string customerWhoOwns, string kindOfAccount, double startingFunds = 0)
    {
        if (accountID <= 0)
            throw new ArgumentException("Account number must be a positive value.", nameof(accountID));
        if (string.IsNullOrWhiteSpace(customerWhoOwns))
            throw new ArgumentException("Owner's name cannot be empty.", nameof(customerWhoOwns));
        if (string.IsNullOrWhiteSpace(kindOfAccount))
            throw new ArgumentException("Account type cannot be blank.", nameof(kindOfAccount));
        if (startingFunds < 0)
            throw new ArgumentException("Starting balance can't be negative.", nameof(startingFunds));

        AccountIdentifier = accountID;
        OwnerName = customerWhoOwns;
        AccountKind = kindOfAccount;
        CurrentBalance = startingFunds;
    }

    public void AddMoney(double amountToPutIn)
    {
        if (amountToPutIn <= 0)
        {
            throw new ArgumentException("Amount to deposit must be greater than zero.", nameof(amountToPutIn));
        }
        CurrentBalance += amountToPutIn;
        Console.WriteLine($"You put in {amountToPutIn:C}. New total: {CurrentBalance:C}");
    }

    public void TakeMoneyOut(double amountToPullOut)
    {
        if (amountToPullOut <= 0)
        {
            throw new ArgumentException("Amount to withdraw must be positive.", nameof(amountToPullOut));
        }

        if (CurrentBalance < amountToPullOut)
        {
            throw new NotEnoughFundsException($"You tried to take out {amountToPullOut:C} but only have {CurrentBalance:C}.");
        }

        CurrentBalance -= amountToPullOut;
        Console.WriteLine($"You took out {amountToPullOut:C}. New total: {CurrentBalance:C}");
    }

    public double GetCurrentBalance()
    {
        return CurrentBalance;
    }

    public void ShowAllAccountInfo()
    {
        Console.WriteLine("\n--- Your Account Details ---");
        Console.WriteLine($"Account Number: {AccountIdentifier}");
        Console.WriteLine($"Account Holder: {OwnerName}");
        Console.WriteLine($"Account Category: {AccountKind}");
        Console.WriteLine($"Your Current Funds: {CurrentBalance:C}");
        Console.WriteLine("---------------------------\n");
    }
}
=======
﻿using System;
public class BankAccount
{
    public int AccountIdentifier { get; private set; }
    public string OwnerName { get; private set; }
    public string AccountKind { get; private set; }
    public double CurrentBalance { get; private set; }

    public BankAccount(int accountID, string customerWhoOwns, string kindOfAccount, double startingFunds = 0)
    {
        if (accountID <= 0)
            throw new ArgumentException("Account number must be a positive value.", nameof(accountID));
        if (string.IsNullOrWhiteSpace(customerWhoOwns))
            throw new ArgumentException("Owner's name cannot be empty.", nameof(customerWhoOwns));
        if (string.IsNullOrWhiteSpace(kindOfAccount))
            throw new ArgumentException("Account type cannot be blank.", nameof(kindOfAccount));
        if (startingFunds < 0)
            throw new ArgumentException("Starting balance can't be negative.", nameof(startingFunds));

        AccountIdentifier = accountID;
        OwnerName = customerWhoOwns;
        AccountKind = kindOfAccount;
        CurrentBalance = startingFunds;
    }

    public void AddMoney(double amountToPutIn)
    {
        if (amountToPutIn <= 0)
        {
            throw new ArgumentException("Amount to deposit must be greater than zero.", nameof(amountToPutIn));
        }
        CurrentBalance += amountToPutIn;
        Console.WriteLine($"You put in {amountToPutIn:C}. New total: {CurrentBalance:C}");
    }

    public void TakeMoneyOut(double amountToPullOut)
    {
        if (amountToPullOut <= 0)
        {
            throw new ArgumentException("Amount to withdraw must be positive.", nameof(amountToPullOut));
        }

        if (CurrentBalance < amountToPullOut)
        {
            throw new NotEnoughFundsException($"You tried to take out {amountToPullOut:C} but only have {CurrentBalance:C}.");
        }

        CurrentBalance -= amountToPullOut;
        Console.WriteLine($"You took out {amountToPullOut:C}. New total: {CurrentBalance:C}");
    }

    public double GetCurrentBalance()
    {
        return CurrentBalance;
    }

    public void ShowAllAccountInfo()
    {
        Console.WriteLine("\n--- Your Account Details ---");
        Console.WriteLine($"Account Number: {AccountIdentifier}");
        Console.WriteLine($"Account Holder: {OwnerName}");
        Console.WriteLine($"Account Category: {AccountKind}");
        Console.WriteLine($"Your Current Funds: {CurrentBalance:C}");
        Console.WriteLine("---------------------------\n");
    }
}
>>>>>>> 68a266f (sqlassignment)
