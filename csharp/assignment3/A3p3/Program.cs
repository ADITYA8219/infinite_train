<<<<<<< HEAD
﻿using System;

class SaleDetails
{
    public int SaleNumber { get; set; }
    public int ProductNumber { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime SaleDate { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; private set; }

    public SaleDetails(int saleNo, int productNo, decimal price, int qty, DateTime saleDate)
    {
        SaleNumber = saleNo;
        ProductNumber = productNo;
        UnitPrice = price;
        Quantity = qty;
        SaleDate = saleDate;
        CalculateTotal(qty, price);
    }

    public void CalculateTotal(int quantity, decimal price)
    {
        TotalAmount = quantity * price;
    }

    public static void ShowData(SaleDetails sale)
    {
        Console.WriteLine($"Sale Number: {sale.SaleNumber}");
        Console.WriteLine($"Product Number: {sale.ProductNumber}");
        Console.WriteLine($"Unit Price: ₹{sale.UnitPrice}");
        Console.WriteLine($"Quantity Sold: {sale.Quantity}");
        Console.WriteLine($"Sale Date: {sale.SaleDate.ToShortDateString()}");
        Console.WriteLine($"Total Amount: ₹{sale.TotalAmount}");
    }
}

class Program
{
    static void Main()
    {
        SaleDetails sale1 = new SaleDetails(12, 2, 1, 3, new DateTime(2025, 6, 25));

        SaleDetails.ShowData(sale1);
        Console.Read();
    }
}
=======
﻿using System;

class SaleDetails
{
    public int SaleNumber { get; set; }
    public int ProductNumber { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime SaleDate { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; private set; }

    public SaleDetails(int saleNo, int productNo, decimal price, int qty, DateTime saleDate)
    {
        SaleNumber = saleNo;
        ProductNumber = productNo;
        UnitPrice = price;
        Quantity = qty;
        SaleDate = saleDate;
        CalculateTotal(qty, price);
    }

    public void CalculateTotal(int quantity, decimal price)
    {
        TotalAmount = quantity * price;
    }

    public static void ShowData(SaleDetails sale)
    {
        Console.WriteLine($"Sale Number: {sale.SaleNumber}");
        Console.WriteLine($"Product Number: {sale.ProductNumber}");
        Console.WriteLine($"Unit Price: ₹{sale.UnitPrice}");
        Console.WriteLine($"Quantity Sold: {sale.Quantity}");
        Console.WriteLine($"Sale Date: {sale.SaleDate.ToShortDateString()}");
        Console.WriteLine($"Total Amount: ₹{sale.TotalAmount}");
    }
}

class Program
{
    static void Main()
    {
        SaleDetails sale1 = new SaleDetails(12, 2, 1, 3, new DateTime(2025, 6, 25));

        SaleDetails.ShowData(sale1);
        Console.Read();
    }
}
>>>>>>> 68a266f (sqlassignment)
