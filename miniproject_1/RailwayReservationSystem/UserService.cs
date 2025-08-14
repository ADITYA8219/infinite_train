using System;
using System.Data.SqlClient;

namespace RailwayReservationSystem
{
    public class UserService
    {
        public void Register()
        {
            Console.WriteLine("\n===== Register New User =====");

            Console.Write("Full Name: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Username: ");
            string username = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Password: ");
            string password = ConsoleHelpers.ReadPassword();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("❌ All fields are required.");
                return;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // Checking if username exists
                using (SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @username", conn))
                {
                    check.Parameters.AddWithValue("@username", username);
                    int count = (int)check.ExecuteScalar();
                    if (count > 0)
                    {
                        Console.WriteLine("❌ Username already exists. Try logging in.");
                        return;
                    }
                }

                using (SqlCommand insert = new SqlCommand(
                    "INSERT INTO Users (FullName, Username, Password) VALUES (@name, @username, @password)", conn))
                {
                    insert.Parameters.AddWithValue("@name", name);
                    insert.Parameters.AddWithValue("@username", username);
                    insert.Parameters.AddWithValue("@password", password);
                    insert.ExecuteNonQuery();
                }

                Console.WriteLine("✅ Registration successful! You can now login.");
            }
        }

        public int Login()
        {
            Console.WriteLine("\n===== User Login =====");

            Console.Write("Username: ");
            string username = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Password: ");
            string password = ConsoleHelpers.ReadPassword();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT UserID FROM Users WHERE Username = @username AND Password = @password", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        Console.WriteLine($" Login successful! Welcome, {username}");
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        Console.WriteLine(" Invalid username or password.");
                        return -1;
                    }
                }
            }
        }

        public void UserMenu(int userId)
        {
            while (true)
            {
                Console.WriteLine("\n===== User Menu =====");
                Console.WriteLine("1. View Trains");
                Console.WriteLine("2. Book Ticket");
                Console.WriteLine("3. View My Bookings");
                Console.WriteLine("4. Cancel Booking");
                Console.WriteLine("0. Logout");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        TrainService.ViewTrains();
                        break;
                    case "2":
                        BookingService.BookTicket(userId);
                        break;
                    case "3":
                        BookingService.ViewUserBookings(userId);
                        break;
                    case "4":
                        BookingService.CancelBooking(userId);
                        break;
                    case "0":
                        Console.WriteLine("Logging out...");
                        return;
                    default:
                        Console.WriteLine("❌ Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
