using System;

public class ScholarshipEvaluator
{
    public static void Main(string[] args)
    {
        Scholarship scholarshipCalculator = new Scholarship();
        double annualFees = 100000.00; 

        Console.WriteLine("--- Scholarship Calculation Demo ---");
        Console.WriteLine($"Total Annual Fees: {annualFees:C}\n");

       
        try
        {
            int studentMarks1 = 75;
            double awardedAmount1 = scholarshipCalculator.Merit(studentMarks1, annualFees);
            Console.WriteLine($"For marks {studentMarks1}: Scholarship Awarded: {awardedAmount1:C}");
        }
        catch (InvalidMarksException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error for marks: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\n-----------------------------------\n");

        try
        {
            int studentMarks2 = 85;
            double awardedAmount2 = scholarshipCalculator.Merit(studentMarks2, annualFees);
            Console.WriteLine($"For marks {studentMarks2}: Scholarship Awarded: {awardedAmount2:C}");
        }
        catch (InvalidMarksException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error for marks: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\n-----------------------------------\n");

        try
        {
            int studentMarks3 = 95;
            double awardedAmount3 = scholarshipCalculator.Merit(studentMarks3, annualFees);
            Console.WriteLine($"For marks {studentMarks3}: Scholarship Awarded: {awardedAmount3:C}");
        }
        catch (InvalidMarksException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error for marks: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\n-----------------------------------\n");
        try
        {
            int studentMarks4 = 60;
            double awardedAmount4 = scholarshipCalculator.Merit(studentMarks4, annualFees);
            Console.WriteLine($"For marks {studentMarks4}: Scholarship Awarded: {awardedAmount4:C}");
        }
        catch (InvalidMarksException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error for marks: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\n-----------------------------------\n");

        try
        {
            int studentMarks5 = -5;
            double awardedAmount5 = scholarshipCalculator.Merit(studentMarks5, annualFees);
            Console.WriteLine($"For marks {studentMarks5}: Scholarship Awarded: {awardedAmount5:C}");
        }
        catch (InvalidMarksException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error for marks: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("\n-----------------------------------\n");
        try
        {
            int studentMarks6 = 105;
            double awardedAmount6 = scholarshipCalculator.Merit(studentMarks6, annualFees);
            Console.WriteLine($"For marks {studentMarks6}: Scholarship Awarded: {awardedAmount6:C}");
        }
        catch (InvalidMarksException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error for marks: {ex.Message}");
            Console.ResetColor();
        }

        Console.ReadKey();
    }
}