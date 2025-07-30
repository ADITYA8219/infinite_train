using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public DateTime DOB { get; set; }
    public DateTime DOJ { get; set; }
    public string City { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Employee> empList = new List<Employee>
        {
            new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
            new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
            new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
            new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
            new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
            new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
            new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
            new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
            new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
            new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
        };

        Console.WriteLine("1. List of employees who joined before 1/1/2015:");
        var joinedBefore2015 = empList.Where(e => e.DOJ < new DateTime(2015, 1, 1));
        foreach (var emp in joinedBefore2015)
        {
            Console.WriteLine($"  - {emp.FirstName} {emp.LastName}, Joined: {emp.DOJ:d}");
        }

        Console.WriteLine("\n2. List of employees born after 1/1/1990:");
        var bornAfter1990 = empList.Where(e => e.DOB > new DateTime(1990, 1, 1));
        foreach (var emp in bornAfter1990)
        {
            Console.WriteLine($"  - {emp.FirstName} {emp.LastName}, DOB: {emp.DOB:d}");
        }

        Console.WriteLine("\n3. List of Consultants and Associates:");
        var consultantsAndAssociates = empList.Where(e => e.Title == "Consultant" || e.Title == "Associate");
        foreach (var emp in consultantsAndAssociates)
        {
            Console.WriteLine($"  - {emp.FirstName} {emp.LastName}, Title: {emp.Title}");
        }

        Console.WriteLine($"\n4. Total number of employees: {empList.Count()}");

        Console.WriteLine($"\n5. Total number of employees in Chennai: {empList.Count(e => e.City == "Chennai")}");

        Console.WriteLine($"\n6. Highest Employee ID: {empList.Max(e => e.EmployeeID)}");

        Console.WriteLine($"\n7. Total employees who joined after 1/1/2015: {empList.Count(e => e.DOJ > new DateTime(2015, 1, 1))}");

        Console.WriteLine($"\n8. Total employees whose title is not 'Associate': {empList.Count(e => e.Title != "Associate")}");

        Console.WriteLine("\n9. Total employees based on City:");
        var cityCounts = empList.GroupBy(e => e.City);
        foreach (var cityGroup in cityCounts)
        {
            Console.WriteLine($"  - {cityGroup.Key}: {cityGroup.Count()}");
        }

        Console.WriteLine("\n10. Total employees based on City and Title:");
        var cityAndTitleCounts = empList.GroupBy(e => new { e.City, e.Title });
        foreach (var group in cityAndTitleCounts)
        {
            Console.WriteLine($"  - {group.Key.City}, {group.Key.Title}: {group.Count()}");
        }

        Console.WriteLine("\n11. Youngest employee in the list:");
        var youngestDob = empList.Max(e => e.DOB);
        var youngestEmployee = empList.First(e => e.DOB == youngestDob);
        Console.WriteLine($"  - {youngestEmployee.FirstName} {youngestEmployee.LastName}, DOB: {youngestEmployee.DOB:d}");
        Console.Read();
    }
}