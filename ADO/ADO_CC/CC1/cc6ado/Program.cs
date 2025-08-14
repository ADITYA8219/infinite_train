using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

public class EmployeeTest
{
    public static void Main(string[] args)
    {
        string connectionString = @"Server=ICS-LAP-6775\SQLEXPRESS;Database=master;Trusted_Connection=True;";

        try
        {
            Console.WriteLine("Enter New Employee Details:");

            Console.Write("Enter Name: ");
            string employeeName = Console.ReadLine();

            decimal givenSalary;
            Console.Write("Enter Salary: ");
            while (!decimal.TryParse(Console.ReadLine(), out givenSalary))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Write("Enter Salary: ");
            }

            Console.Write("Enter Gender M or F: ");
            string gender = Console.ReadLine();
            Console.WriteLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("insertempdet", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", employeeName);
                    cmd.Parameters.AddWithValue("@givenSalary", givenSalary);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    SqlParameter outputIdParam = new SqlParameter("@GeneratedEmpId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);

                    connection.Open();
                    cmd.ExecuteNonQuery();

                    int generatedId = (int)outputIdParam.Value;
                    decimal calculatedSalary = givenSalary * 0.90m;
                    

                    Console.WriteLine("Employee successfully inserted!");
                    Console.WriteLine($"Generated EmpId: {generatedId}");
                    Console.WriteLine($"Calculated Salary: {calculatedSalary:C}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}