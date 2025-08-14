using System;
using System.Data.SqlClient;

namespace RailwayReservationSystem
{
    public class AdminService
    {
        private const string adminUser = "admin";
        private const string adminPass = "admin123";

        public bool Login()
        {
            Console.WriteLine("\n===== Admin Login =====");
            Console.Write("Username: ");
            string username = Console.ReadLine()?.Trim() ?? "";
            Console.Write("Password: ");
            string password = ConsoleHelpers.ReadPassword();

            return string.Equals(username, adminUser, StringComparison.OrdinalIgnoreCase)
                && password == adminPass;
        }

        public void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== Admin Menu =====");
                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. View All Trains");
                Console.WriteLine("3. View Booking Statistics");
                Console.WriteLine("4. Soft Delete Train");
                Console.WriteLine("0. Logout");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        AddTrain();
                        break;
                    case "2":
                        TrainService.ViewTrains();
                        break;
                    case "3":
                        ViewBookingStats();
                        break;
                    case "4":
                        SoftDeleteTrain();
                        break;

                    case "0":
                        Console.WriteLine("Logging out...");
                        return;
                    default:
                        Console.WriteLine("❌ Invalid choice.");
                        break;
                }
            }
        }
        private void SoftDeleteTrain()
        {
            Console.WriteLine("\n===== Soft Delete Train =====");
            TrainService.ViewTrains();  
            Console.Write("\nEnter Train ID to delete: ");

            if (!int.TryParse(Console.ReadLine()?.Trim(), out int trainId))
            {
                Console.WriteLine("Invalid Train ID.");
                return;
            }

            using (var conn = Database.GetConnection())
            {
                conn.Open();

                using (var checkCmd = new SqlCommand("SELECT COUNT(*) FROM Trains WHERE TrainID = @id AND IsDeleted = 0", conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", trainId);
                    if ((int)checkCmd.ExecuteScalar() == 0)
                    {
                        Console.WriteLine(" Train not found or already deleted.");
                        return;
                    }
                }

                using (var cmd = new SqlCommand("UPDATE Trains SET IsDeleted = 1 WHERE TrainID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", trainId);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine($" Train ID {trainId} marked as deleted.");
            }
        }

        private void AddTrain()
        {
            Console.WriteLine("\n===== Add New Train =====");

            Console.Write("Train Number (e.g., 12345): ");
            string trainNumber = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrEmpty(trainNumber))
            {
                Console.WriteLine(" Train number cannot be empty.");
                return;
            }

            Console.Write("Train Name: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Source Station: ");
            string source = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Destination Station: ");
            string destination = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Distance (in KM): ");
            if (!int.TryParse(Console.ReadLine(), out int distance) || distance <= 0)
            {
                Console.WriteLine("Invalid distance.");
                return;
            }

            Console.Write("Departure Time (HH:mm): ");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan depTime))
            {
                Console.WriteLine("Invalid departure time format.");
                return;
            }

            Console.Write("Arrival Time (HH:mm): ");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan arrTime))
            {
                Console.WriteLine("Invalid arrival time format.");
                return;
            }

            DateTime today = DateTime.Today;
            DateTime departure = today.Add(depTime);
            DateTime arrival = today.Add(arrTime);
            if (arrTime < depTime)
                arrival = arrival.AddDays(1);

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Checking if train number exists
                        using (var checkCmd = new SqlCommand("SELECT COUNT(*) FROM Trains WHERE TrainNumber = @trainNumber", conn, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@trainNumber", trainNumber);
                            int count = (int)checkCmd.ExecuteScalar();
                            if (count > 0)
                            {
                                Console.WriteLine("Train number already exists!");
                                transaction.Rollback();
                                return;
                            }
                        }

                        // Inserting into Trains
                        using (var trainCmd = new SqlCommand(@"
                            INSERT INTO Trains (TrainNumber, TrainName, Source, Destination, DepartureTime, ArrivalTime, Distance) 
                            OUTPUT INSERTED.TrainID 
                            VALUES (@trainNumber, @name, @source, @destination, @dep, @arr, @distance)", conn, transaction))
                        {
                            trainCmd.Parameters.AddWithValue("@trainNumber", trainNumber);
                            trainCmd.Parameters.AddWithValue("@name", name);
                            trainCmd.Parameters.AddWithValue("@source", source);
                            trainCmd.Parameters.AddWithValue("@destination", destination);
                            trainCmd.Parameters.AddWithValue("@dep", departure);
                            trainCmd.Parameters.AddWithValue("@arr", arrival);
                            trainCmd.Parameters.AddWithValue("@distance", distance);

                            int trainId = (int)trainCmd.ExecuteScalar();

                           
                            Console.WriteLine("\n===== Configure Travel Classes =====");
                            string[] classes = { "1AC", "2AC", "3AC", "SL", "General" };
                            string[] classNames = { "First AC", "Second AC", "Third AC", "Sleeper", "General" };
                            decimal[] baseFares = { 3.0m, 2.0m, 1.5m, 1.0m, 0.5m }; // per KM

                            for (int i = 0; i < classes.Length; i++)
                            {
                                Console.Write($"Add {classNames[i]} ({classes[i]})? (y/n): ");
                                string response = Console.ReadLine()?.Trim().ToLowerInvariant() ?? "n";

                                if (response == "y" || response == "yes")
                                {
                                    Console.Write($"Total seats in {classNames[i]}: ");
                                    if (int.TryParse(Console.ReadLine(), out int totalSeats) && totalSeats > 0)
                                    {
                                        decimal suggestedFare = Math.Round(baseFares[i] * distance, 2);
                                        Console.Write($"Fare per seat for {classNames[i]} (Suggested: ₹{suggestedFare}): ");
                                        string fareInput = Console.ReadLine()?.Trim();

                                        decimal fare = suggestedFare;
                                        if (!string.IsNullOrEmpty(fareInput) && decimal.TryParse(fareInput, out decimal customFare) && customFare > 0)
                                            fare = customFare;

                                        using (var classCmd = new SqlCommand(@"
                                            INSERT INTO TrainClasses (TrainID, ClassName, SeatsAvailable, TotalSeats, Fare) 
                                            VALUES (@trainId, @className, @totalSeats, @totalSeats, @fare)", conn, transaction))
                                        {
                                            classCmd.Parameters.AddWithValue("@trainId", trainId);
                                            classCmd.Parameters.AddWithValue("@className", classes[i]);
                                            classCmd.Parameters.AddWithValue("@totalSeats", totalSeats);
                                            classCmd.Parameters.AddWithValue("@fare", fare);
                                            classCmd.ExecuteNonQuery();
                                        }

                                        Console.WriteLine($" {classNames[i]} added: {totalSeats} seats at ₹{fare} each");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid seat count, skipping this class.");
                                    }
                                }
                            }

                            transaction.Commit();
                            TimeSpan duration = arrival - departure;

                            Console.WriteLine($"\nTrain {trainNumber} - {name} added successfully!");
                            Console.WriteLine($"Route: {source} → {destination} ({distance} KM)");
                            Console.WriteLine($"Duration: {duration.Hours}h {duration.Minutes}m");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error adding train: " + ex.Message);
                    }
                }
            }
        }

        private void ViewBookingStats()
        {
            Console.WriteLine("\n===== Booking Statistics =====");

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        t.TrainNumber,
                        t.TrainName,
                        COUNT(b.BookingID) as TotalBookings,
                        ISNULL(SUM(b.SeatsBooked), 0) as TotalSeats,
                        ISNULL(SUM(b.TotalCost), 0) as Revenue,
                        COUNT(CASE WHEN b.BookingStatus = 'Cancelled' THEN 1 END) as Cancellations
                    FROM Trains t
                    LEFT JOIN Bookings b ON t.TrainID = b.TrainID
                    GROUP BY t.TrainNumber, t.TrainName
                    ORDER BY Revenue DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("Train No.\tTrain Name\t\tBookings\tSeats\tRevenue\t\tCancellations");
                    Console.WriteLine(new string('=', 90));

                    while (reader.Read())
                    {
                        string trainNumber = reader.GetString(0);
                        string trainName = reader.GetString(1);
                        int bookings = reader.GetInt32(2);
                        int seats = reader.GetInt32(3);
                        decimal revenue = reader.GetDecimal(4);
                        int cancellations = reader.GetInt32(5);

                        Console.WriteLine($"{trainNumber}\t{trainName.PadRight(16)}\t{bookings}\t\t{seats}\t₹{revenue:F2}\t\t{cancellations}");
                    }
                }
            }
        }
    }
}
