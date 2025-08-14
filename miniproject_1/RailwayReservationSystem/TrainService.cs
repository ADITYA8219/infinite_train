using System;
using System.Data.SqlClient;

namespace RailwayReservationSystem
{
    public static class TrainService
    {
        public static void ViewTrains()
        {
            Console.WriteLine("\n===== Available Trains =====");

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string query = @"
    SELECT t.TrainID, t.TrainNumber, t.TrainName, t.Source, t.Destination, 
           t.DepartureTime, t.ArrivalTime, t.Distance, t.Duration,
           tc.ClassName, tc.SeatsAvailable, tc.TotalSeats, tc.Fare
    FROM Trains t
    INNER JOIN TrainClasses tc ON t.TrainID = tc.TrainID
    WHERE tc.SeatsAvailable > 0 AND t.IsDeleted = 0
    ORDER BY t.TrainNumber, 
    CASE tc.ClassName 
        WHEN '1AC' THEN 1 WHEN '2AC' THEN 2 WHEN '3AC' THEN 3 
        WHEN 'SL' THEN 4 WHEN 'General' THEN 5 
    END";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No trains with available seats found.");
                        return;
                    }

                    Console.WriteLine("Train Details & Available Classes");
                    Console.WriteLine(new string('=', 120));

                    int currentTrainId = -1;
                    while (reader.Read())
                    {
                        int trainId = reader.GetInt32(0);
                        string trainNumber = reader.GetString(1);
                        string trainName = reader.GetString(2);
                        string source = reader.GetString(3);
                        string dest = reader.GetString(4);
                        DateTime dep = reader.GetDateTime(5);
                        DateTime arr = reader.GetDateTime(6);
                        int distance = reader.GetInt32(7);
                        int durationMins = reader.GetInt32(8);
                        string className = reader.GetString(9);
                        int availableSeats = reader.GetInt32(10);
                        int totalSeats = reader.GetInt32(11);
                        decimal fare = reader.GetDecimal(12);

                        if (currentTrainId != trainId)
                        {
                            if (currentTrainId != -1) Console.WriteLine();

                            TimeSpan duration = TimeSpan.FromMinutes(durationMins);
                            string durationStr = duration.Days > 0 ?
                                $"{duration.Days}d {duration.Hours}h {duration.Minutes}m" :
                                $"{duration.Hours}h {duration.Minutes}m";

                            currentTrainId = trainId;
                            Console.WriteLine($" Train ID: {trainId} | {trainNumber} - {trainName}");
                            Console.WriteLine($"   Route: {source} → {dest} ({distance} KM)");
                            Console.WriteLine($"   Time: {dep:HH:mm} → {arr:HH:mm} ({durationStr})");
                            Console.WriteLine("   Classes Available:");
                        }

                        string occupancy = totalSeats > 0 ? $"({availableSeats}/{totalSeats})" : "";
                        Console.WriteLine($"   • {className.PadRight(8)} | ₹{fare:F2} | {availableSeats} seats {occupancy}");
                    }
                }
            }
        }

        public static bool GetTrainClassDetails(int trainId, string className, out decimal fare, out int availableSeats, out string trainInfo)
        {
            fare = 0;
            availableSeats = 0;
            trainInfo = "";

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT tc.Fare, tc.SeatsAvailable, t.TrainNumber, t.TrainName, 
                       t.Source, t.Destination, t.DepartureTime, t.ArrivalTime, t.Distance
                FROM TrainClasses tc
                INNER JOIN Trains t ON tc.TrainID = t.TrainID
                WHERE tc.TrainID = @trainId AND tc.ClassName = @className AND t.IsDeleted = 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@trainId", trainId);
                    cmd.Parameters.AddWithValue("@className", className);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fare = reader.GetDecimal(0);
                            availableSeats = reader.GetInt32(1);
                            string trainNumber = reader.GetString(2);
                            string trainName = reader.GetString(3);
                            string source = reader.GetString(4);
                            string destination = reader.GetString(5);
                            DateTime departure = reader.GetDateTime(6);
                            DateTime arrival = reader.GetDateTime(7);
                            int distance = reader.GetInt32(8);

                            trainInfo = $"{trainNumber} - {trainName} | {source} → {destination} | " +
                                       $"{departure:HH:mm} → {arrival:HH:mm} | {distance} KM";
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
    }
}
