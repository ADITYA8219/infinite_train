using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int EmpId { get; set; }
    public string EmpName { get; set; }
    public string EmpCity { get; set; }
    public decimal EmpSalary { get; set; }
}

public class EmployeeManagement
{
    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { EmpId = 101, EmpName = "Ram", EmpCity = "Bangalore", EmpSalary = 55000M },
            new Employee { EmpId = 102, EmpName = "shyam", EmpCity = "Chennai", EmpSalary = 42000M },
            new Employee { EmpId = 103, EmpName = "rahul", EmpCity = "Bangalore", EmpSalary = 60000M },
            new Employee { EmpId = 104, EmpName = "Dev", EmpCity = "Hyderabad", EmpSalary = 38000M },
            new Employee { EmpId = 105, EmpName = "Raj", EmpCity = "Bangalore", EmpSalary = 48000M },
            new Employee { EmpId = 106, EmpName = "Ravi", EmpCity = "Mumbai", EmpSalary = 70000M }
        };

        Console.WriteLine("Employee Management System");
        Console.WriteLine("a. Display all employees data");
        Console.WriteLine("b. Display employees with salary greater than 45000");
        Console.WriteLine("c. Display employees from Bangalore region");
        Console.WriteLine("d. Display employees by name in ascending order");
        Console.Write("Enter your choice (a, b, c, or d): ");
        string userChoice = Console.ReadLine().ToLower();

        switch (userChoice)
        {
            case "a":
                Console.WriteLine("\nAll Employees Data:");
                DisplayEmployees(employees);
                break;
            case "b":
                Console.WriteLine("\nEmployees with Salary > 45000:");
                var highSalaryEmployees = employees.Where(emp => emp.EmpSalary > 45000M).ToList();
                DisplayEmployees(highSalaryEmployees);
                break;
            case "c":
                Console.WriteLine("\nEmployees from Bangalore:");
                var bangaloreEmployees = employees.Where(emp => emp.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase)).ToList();
                DisplayEmployees(bangaloreEmployees);
                break;
            case "d":
                Console.WriteLine("\nEmployees by Name (Ascending Order):");
                var sortedEmployees = employees.OrderBy(emp => emp.EmpName).ToList();
                DisplayEmployees(sortedEmployees);
                break;
            default:
                Console.WriteLine("Invalid choice. Please select a, b, c, or d.");
                break;
        }

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }

    public static void DisplayEmployees(List<Employee> employeesToDisplay)
    {
        if (!employeesToDisplay.Any())
        {
            Console.WriteLine("No employees to display.");
            return;
        }

        Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10}", "EmpId", "EmpName", "EmpCity", "EmpSalary");
        Console.WriteLine("----------------------------------------------------------");
        foreach (var employee in employeesToDisplay)
        {
            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10:N0}",
                              employee.EmpId, employee.EmpName, employee.EmpCity, employee.EmpSalary);
        }
    }
}