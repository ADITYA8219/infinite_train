using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generics
{

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }

        public void DisplayDetails()
        {
            Console.WriteLine($"ID: {EmployeeID}, Name: {FirstName} {LastName}, Title: {Title}, DOB: {DOB.ToShortDateString()}, DOJ: {DOJ.ToShortDateString()}, City: {City}");
        }
    }

    public class EmployeeData
    {
        public static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
        {
            new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
            new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1994, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
            new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
            new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
            new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
            new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
            new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
            new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
            new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
            new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
        };

            Console.WriteLine("Displaying Details of all employees:");
            foreach (var emp in empList)
            {
                emp.DisplayDetails();
            }

            Console.WriteLine("\n********");

            Console.WriteLine("Displaying Details of employees whose location is NOT Mumbai:");
            var empnotinMumbai = empList.Where(emp => emp.City != "Mumbai");
            foreach (var emp in empnotinMumbai)
            {
                emp.DisplayDetails();
            }

            Console.WriteLine("\n********");

            Console.WriteLine("Displaying of employees whose title is AsstManager:");
            var it = empList.Where(emp => emp.Title == "AsstManager");
            foreach (var emp in it)
            {
                emp.DisplayDetails();
            }

            Console.WriteLine("\n********");

            Console.WriteLine("Displaying of employees whose Last Name starts with S:");
            var lastWithS = empList.Where(emp => emp.LastName.StartsWith("S"));
            foreach (var emp in lastWithS)
            {
                emp.DisplayDetails();
            }

            Console.Read();
        }
    }

}
