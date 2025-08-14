using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

public class EmployeeUpdateTest
{
    public static void Main(string[] args)
    {
        string connectionString = @"Server=ICS-LAP-6775\SQLEXPRESS;Database=master;Trusted_Connection=True;";

        try
        {
            int employeeIdToUpdate;
            Console.Write("Please enter the Employee ID to update (1001 to 1006): ");
            while (!int.TryParse(Console.ReadLine(), out employeeIdToUpdate))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                Console.Write("Please enter the Employee ID to update: ");
            }
            Console.WriteLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                decimal previousSalary = 0;

                using (SqlCommand getSalaryCmd = new SqlCommand("SELECT Salary FROM Employee_Details WHERE Empid = @Empid", connection))
                {
                    getSalaryCmd.Parameters.AddWithValue("@Empid", employeeIdToUpdate);
                    object result = getSalaryCmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        Console.WriteLine($"Oopssiiii...........No employee found with this ID {employeeIdToUpdate}");
                        Console.WriteLine("\nPress Enter to exit...");
                        Console.ReadLine();
                        return;
                    }
                    previousSalary = (decimal)result;
                }

                using (SqlCommand updateCmd = new SqlCommand("updateempsalary", connection))
                {
                    updateCmd.CommandType = CommandType.StoredProcedure;
                    updateCmd.Parameters.AddWithValue("@Empid", employeeIdToUpdate);

                    SqlParameter newSalaryParam = new SqlParameter("@NewSalary", SqlDbType.Decimal)
                    {
                        Precision = 10,
                        Scale = 2,
                        Direction = ParameterDirection.Output
                    };
                    updateCmd.Parameters.Add(newSalaryParam);

                    updateCmd.ExecuteNonQuery();

                    Console.WriteLine($"Update successful for Employee ID with {employeeIdToUpdate}.");
                    Console.WriteLine("--------------------------------------------------");
                }

                Console.WriteLine("Here's is the newly updated employee details...");
                using (SqlCommand selectCmd = new SqlCommand("SELECT Empid, Name, Salary, Gender FROM Employee_Details WHERE Empid = @Empid", connection))
                {
                    selectCmd.Parameters.AddWithValue("@Empid", employeeIdToUpdate);

                    using (SqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CultureInfo usCulture = new CultureInfo("en-US");
                            Console.WriteLine($"   ID: {reader["Empid"]}");
                            Console.WriteLine($"   Name: {reader["Name"]}");
                            Console.WriteLine($"   Previous Salary: {previousSalary.ToString("C", usCulture)}");
                            Console.WriteLine($"   Updated Salary: {((decimal)reader["Salary"]).ToString("C", usCulture)}");
                            Console.WriteLine($"   Gender: {reader["Gender"]}");
                        }
                    }
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