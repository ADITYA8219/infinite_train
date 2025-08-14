using System;

namespace RailwayReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();
            var adminService = new AdminService();

            while (true)
            {
                Console.WriteLine("\n===== Railway Reservation System =====");
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. User Login");
                Console.WriteLine("3. Register as New User");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        if (adminService.Login())
                        {
                            adminService.AdminMenu();
                        }
                        else
                        {
                            Console.WriteLine("❌ Invalid admin credentials.");
                        }
                        break;

                    case "2":

                        int userId = userService.Login();
                        if (userId != -1)
                        {
                            userService.UserMenu(userId);
                        }
                        break;

                    case "3":
                     
                        userService.Register();
                        break;

                    case "0":
                        Console.WriteLine("Thank you for using Railway Reservation System.");
                        return;

                    default:
                        Console.WriteLine("❌ Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
