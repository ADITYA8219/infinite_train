using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Department: {Department}, Salary: {Salary:C}";
    }
}

public class EmployeeManagementSystem
{
    private List<Employee> employees = new List<Employee>();
    private int nextId = 1; // To auto-increment employee IDs

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                    ViewAllEmployees();
                    break;
                case "3":
                    SearchEmployeeById();
                    break;
                case "4":
                    UpdateEmployeeDetails();
                    break;
                case "5":
                    DeleteEmployee();
                    break;
                case "6":
                    exit = true;
                    Console.WriteLine("Exiting System. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("===== Employee Management Menu =====");
        Console.WriteLine("1. Add New Employee");
        Console.WriteLine("2. View All Employees");
        Console.WriteLine("3. Search Employee by ID");
        Console.WriteLine("4. Update Employee Details");
        Console.WriteLine("5. Delete Employee");
        Console.WriteLine("6. Exit");
        Console.WriteLine("====================================");
        Console.Write("Enter your choice: ");
    }

    private void AddEmployee()
    {
        Console.WriteLine("\n--- Add New Employee ---");
        Employee newEmployee = new Employee();
        newEmployee.Id = nextId++;

        Console.Write("Enter Employee Name: ");
        newEmployee.Name = Console.ReadLine();

        Console.Write("Enter Department: ");
        newEmployee.Department = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double salary;
        while (!double.TryParse(Console.ReadLine(), out salary) || salary < 0)
        {
            Console.WriteLine("Invalid salary. Please enter a valid non-negative number.");
            Console.Write("Enter Salary: ");
        }
        newEmployee.Salary = salary;

        employees.Add(newEmployee);
        Console.WriteLine($"Employee '{newEmployee.Name}' added successfully with ID: {newEmployee.Id}.");
    }

    private void ViewAllEmployees()
    {
        Console.WriteLine("\n--- All Employees ---");
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees to display.");
            return;
        }

        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }

    private void SearchEmployeeById()
    {
        Console.WriteLine("\n--- Search Employee by ID ---");
        Console.Write("Enter Employee ID to search: ");
        if (!int.TryParse(Console.ReadLine(), out int idToSearch))
        {
            Console.WriteLine("Invalid ID. Please enter a number.");
            return;
        }

        Employee foundEmployee = employees.FirstOrDefault(e => e.Id == idToSearch);

        if (foundEmployee != null)
        {
            Console.WriteLine("Employee Found:");
            Console.WriteLine(foundEmployee);
        }
        else
        {
            Console.WriteLine($"Employee with ID {idToSearch} not found.");
        }
    }

    private void UpdateEmployeeDetails()
    {
        Console.WriteLine("\n--- Update Employee Details ---");
        Console.Write("Enter Employee ID to update: ");
        if (!int.TryParse(Console.ReadLine(), out int idToUpdate))
        {
            Console.WriteLine("Invalid ID. Please enter a number.");
            return;
        }

        Employee employeeToUpdate = employees.FirstOrDefault(e => e.Id == idToUpdate);

        if (employeeToUpdate != null)
        {
            Console.WriteLine("Employee Found. Enter new details (leave blank to keep current value):");
            Console.WriteLine($"Current Name: {employeeToUpdate.Name}");
            Console.Write("Enter New Name: ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                employeeToUpdate.Name = newName;
            }

            Console.WriteLine($"Current Department: {employeeToUpdate.Department}");
            Console.Write("Enter New Department: ");
            string newDepartment = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDepartment))
            {
                employeeToUpdate.Department = newDepartment;
            }

            Console.WriteLine($"Current Salary: {employeeToUpdate.Salary:C}");
            Console.Write("Enter New Salary: ");
            string newSalaryInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newSalaryInput))
            {
                if (double.TryParse(newSalaryInput, out double newSalary) && newSalary >= 0)
                {
                    employeeToUpdate.Salary = newSalary;
                }
                else
                {
                    Console.WriteLine("Invalid salary format. Salary not updated.");
                }
            }

            Console.WriteLine($"Employee with ID {idToUpdate} updated successfully.");
        }
        else
        {
            Console.WriteLine($"Employee with ID {idToUpdate} not found.");
        }
    }

    private void DeleteEmployee()
    {
        Console.WriteLine("\n--- Delete Employee ---");
        Console.Write("Enter Employee ID to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int idToDelete))
        {
            Console.WriteLine("Invalid ID. Please enter a number.");
            return;
        }

        Employee employeeToDelete = employees.FirstOrDefault(e => e.Id == idToDelete);

        if (employeeToDelete != null)
        {
            employees.Remove(employeeToDelete);
            Console.WriteLine($"Employee '{employeeToDelete.Name}' with ID {idToDelete} deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Employee with ID {idToDelete} not found.");
        }
    }

    public static void Main(string[] args)
    {
        EmployeeManagementSystem ems = new EmployeeManagementSystem();
        ems.Run();
    }
}