using System;

public class Scholarship
{
    public double Merit(int studentScore, double totalFees)
    {
        if (studentScore < 0 || studentScore > 100)
        {
            throw new InvalidMarksException($"The score {studentScore} is not within the valid range of 0 to 100.");
        }

        if (totalFees < 0)
        {
            Console.WriteLine("Heads up: Fees cannot be negative. Assuming fees are 0 for calculation.");
            totalFees = 0;
        }

        double scholarshipValue = 0;

        if (studentScore >= 70 && studentScore <= 80)
        {
            scholarshipValue = 0.20 * totalFees; 
        }
        else if (studentScore > 80 && studentScore <= 90)
        {
            scholarshipValue = 0.30 * totalFees; 
        }
        else if (studentScore > 90)
        {
            scholarshipValue = 0.50 * totalFees; 
        }
        
        return scholarshipValue;
    }
}