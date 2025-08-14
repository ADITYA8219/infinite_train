using System;
using System.Data.SqlClient;

namespace RailwayReservationSystem
{
    public static class BookingService
    {
        public static void BookTicket(int userId)
        {
            Console.WriteLine("\n===== Book Train Ticket =====");
            TrainService.ViewTrains();

            Console.Write("\nEnter Train ID to book: ");
            if (!int.TryParse(Console.ReadLine()?.Trim(), out int trainId))
            {
                Console.WriteLine("Invalid Train ID.");
                return;
            }

            Console.WriteLine("\n Available Travel Classes:");
            Console.WriteLine("1. 1AC (First AC) - Premium comfort with AC");
            Console.WriteLine("2. 2AC (Second AC) - Comfortable AC sleeper");
            Console.WriteLine("3. 3AC (Third AC) - Economy AC sleeper");
            Console.WriteLine("4. SL (Sleeper) - Non-AC sleeper");
            Console.WriteLine("5. General - Basic seating");

            Console.Write("Select class (1-5): ");
            string[] classOptions = { "1AC", "2AC", "3AC", "SL", "General" };
            if (!int.TryParse(Console.ReadLine()?.Trim(), out int classChoice) || classChoice < 1 || classChoice > 5)
            {
                Console.WriteLine(" Invalid class selection.");
                return;
            }

            string selectedClass = classOptions[classChoice - 1];

            Console.Write("Enter number of passengers: ");
            if (!int.TryParse(Console.ReadLine()?.Trim(), out int seatsToBook) || seatsToBook <= 0)
            {
                Console.WriteLine(" Invalid number of passengers.");
                return;
            }

            Console.Write("Journey date (YYYY-MM-DD) or u can press Enter for today: ");
            string dateInput = Console.ReadLine()?.Trim();
            DateTime journeyDate = DateTime.Today;

            if (!string.IsNullOrEmpty(dateInput))
            {
                if (!DateTime.TryParse(dateInput, out journeyDate) || journeyDate < DateTime.Today)
                {
                    Console.WriteLine("Invalid date or past date selected.");
                    return;
                }
            }

            if (!TrainService.GetTrainClassDetails(trainId, selectedClass, out decimal fare, out int availableSeats, out string trainInfo))
            {
                Console.WriteLine(" Train or class not found.");
                return;
            }

            if (availableSeats < seatsToBook)
            {
                Console.WriteLine($"Only {availableSeats} seats available in {selectedClass} class.");
                return;
            }

            decimal totalCost = fare * seatsToBook;

            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine(" BOOKING CONFIRMATION");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine($"Train: {trainInfo}");
            Console.WriteLine($"Journey Date: {journeyDate:dddd, dd MMMM yyyy}");
            Console.WriteLine($"Class: {selectedClass}");
            Console.WriteLine($"Passengers: {seatsToBook}");
            Console.WriteLine($"Fare per seat: ₹{fare:F2}");
            Console.WriteLine($"Total Amount: ₹{totalCost:F2}");
            Console.WriteLine(new string('=', 60));

            Console.Write("Confirm booking? (y/n): ");
            if (Console.ReadLine()?.Trim().ToLowerInvariant() != "y")
            {
                Console.WriteLine(" Booking cancelled by user.");
                return;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string getTrainQuery = @"
                            SELECT TrainNumber, TrainName, Source, Destination, DepartureTime, ArrivalTime
                            FROM Trains WHERE TrainID = @trainId";

                        using (var trainCmd = new SqlCommand(getTrainQuery, conn, transaction))
                        {
                            trainCmd.Parameters.AddWithValue("@trainId", trainId);

                            using (var trainReader = trainCmd.ExecuteReader())
                            {
                                if (!trainReader.HasRows)
                                {
                                    Console.WriteLine(" Train not found.");
                                    transaction.Rollback();
                                    return;
                                }

                                trainReader.Read();
                                string trainNumber = trainReader.GetString(0);
                                string trainName = trainReader.GetString(1);
                                string source = trainReader.GetString(2);
                                string destination = trainReader.GetString(3);
                                DateTime departureTime = trainReader.GetDateTime(4);
                                DateTime arrivalTime = trainReader.GetDateTime(5);
                                trainReader.Close();

                                string insertBookingSql = @"
                                    INSERT INTO Bookings (
                                        UserID, TrainID, TrainNumber, TrainName, Source, Destination,
                                        JourneyDate, DepartureTime, ArrivalTime, ClassName,
                                        SeatsBooked, FarePerSeat, TotalCost, BookingStatus
                                    ) VALUES (
                                        @userId, @trainId, @trainNumber, @trainName, @source, @destination,
                                        @journeyDate, @departureTime, @arrivalTime, @className,
                                        @seats, @farePerSeat, @totalCost, 'Confirmed'
                                    )";

                                using (var insertBooking = new SqlCommand(insertBookingSql, conn, transaction))
                                {
                                    insertBooking.Parameters.AddWithValue("@userId", userId);
                                    insertBooking.Parameters.AddWithValue("@trainId", trainId);
                                    insertBooking.Parameters.AddWithValue("@trainNumber", trainNumber);
                                    insertBooking.Parameters.AddWithValue("@trainName", trainName);
                                    insertBooking.Parameters.AddWithValue("@source", source);
                                    insertBooking.Parameters.AddWithValue("@destination", destination);
                                    insertBooking.Parameters.AddWithValue("@journeyDate", journeyDate);
                                    insertBooking.Parameters.AddWithValue("@departureTime", departureTime.TimeOfDay);
                                    insertBooking.Parameters.AddWithValue("@arrivalTime", arrivalTime.TimeOfDay);
                                    insertBooking.Parameters.AddWithValue("@className", selectedClass);
                                    insertBooking.Parameters.AddWithValue("@seats", seatsToBook);
                                    insertBooking.Parameters.AddWithValue("@farePerSeat", fare);
                                    insertBooking.Parameters.AddWithValue("@totalCost", totalCost);

                                    insertBooking.ExecuteNonQuery();
                                }

                                string updateSeatsSql = @"
                                    UPDATE TrainClasses 
                                    SET SeatsAvailable = SeatsAvailable - @seats 
                                    WHERE TrainID = @trainId AND ClassName = @className";

                                using (var updateSeats = new SqlCommand(updateSeatsSql, conn, transaction))
                                {
                                    updateSeats.Parameters.AddWithValue("@seats", seatsToBook);
                                    updateSeats.Parameters.AddWithValue("@trainId", trainId);
                                    updateSeats.Parameters.AddWithValue("@className", selectedClass);
                                    updateSeats.ExecuteNonQuery();
                                }

                                transaction.Commit();

                                Console.WriteLine("\nBOOKING SUCCESSFUL!");
                                Console.WriteLine($" {seatsToBook} seats confirmed in {selectedClass} class");
                                Console.WriteLine($" Total amount: ₹{totalCost:F2}");
                                Console.WriteLine($" Journey: {journeyDate:dd MMM yyyy}");
                                Console.WriteLine(" Booking confirmation will be sent via email.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine(" Booking failed: " + ex.Message);
                    }
                }
            }
        }

        public static void ViewUserBookings(int userId)
        {
            Console.WriteLine("\n===== Your Travel History =====");

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string query = @"
                SELECT BookingID, TrainNumber, TrainName, Source, Destination,
                       JourneyDate, DepartureTime, ArrivalTime, ClassName, 
                       SeatsBooked, FarePerSeat, TotalCost, BookingStatus, 
                       BookingDate, CancellationDate
                FROM Bookings 
                WHERE UserID = @userId 
                ORDER BY JourneyDate DESC, BookingDate DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("You have no bookings yet.");
                            return;
                        }

                        decimal totalSpent = 0;
                        int confirmedBookings = 0;
                        int cancelledBookings = 0;

                        while (reader.Read())
                        {
                            int bookingId = reader.GetInt32(0);
                            string trainNumber = reader.GetString(1);
                            string trainName = reader.GetString(2);
                            string source = reader.GetString(3);
                            string destination = reader.GetString(4);
                            DateTime journeyDate = reader.GetDateTime(5);
                            TimeSpan departureTime = reader.GetTimeSpan(6);
                            TimeSpan arrivalTime = reader.GetTimeSpan(7);
                            string className = reader.GetString(8);
                            int seatsBooked = reader.GetInt32(9);
                            decimal farePerSeat = reader.GetDecimal(10);
                            decimal totalCost = reader.GetDecimal(11);
                            string status = reader.GetString(12);
                            DateTime bookingDate = reader.GetDateTime(13);
                            DateTime? cancellationDate = reader.IsDBNull(14) ? (DateTime?)null : reader.GetDateTime(14);

                            string statusIcon = status == "Confirmed" ? "✅" : "❌";
                            string statusText = status == "Confirmed" ? "CONFIRMED" : "CANCELLED";

                            Console.WriteLine("\n" + new string('-', 80));
                            Console.WriteLine($"{statusIcon} Booking ID: {bookingId} - {statusText}");
                            Console.WriteLine($" Train: {trainNumber} - {trainName}");
                            Console.WriteLine($" Route: {source} → {destination}");
                            Console.WriteLine($" Journey: {journeyDate:dddd, dd MMM yyyy}");
                            Console.WriteLine($" Time: {departureTime:hh\\:mm} → {arrivalTime:hh\\:mm}");
                            Console.WriteLine($" Class: {className} | Passengers: {seatsBooked}");
                            Console.WriteLine($" Fare: ₹{farePerSeat:F2} × {seatsBooked} = ₹{totalCost:F2}");
                            Console.WriteLine($" Booked: {bookingDate:dd MMM yyyy HH:mm}");

                            if (cancellationDate.HasValue)
                            {
                                Console.WriteLine($" Cancelled: {cancellationDate:dd MMM yyyy HH:mm}");
                            }

                            if (status == "Confirmed")
                            {
                                totalSpent += totalCost;
                                confirmedBookings++;
                            }
                            else
                            {
                                cancelledBookings++;
                            }
                        }

                        Console.WriteLine("\n" + new string('=', 80));
                        Console.WriteLine($" BOOKING SUMMARY");
                        Console.WriteLine($" Confirmed Bookings: {confirmedBookings}");
                        Console.WriteLine($" Cancelled Bookings: {cancelledBookings}");
                        Console.WriteLine($" Total Amount Spent: ₹{totalSpent:F2}");
                        Console.WriteLine(new string('=', 80));
                    }
                }
            }
        }

        public static void CancelBooking(int userId)
        {
            Console.WriteLine("\n===== Cancel Booking =====");

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string query = @"
                SELECT BookingID, TrainNumber, TrainName, Source, Destination,
                       JourneyDate, DepartureTime, ArrivalTime, ClassName, 
                       SeatsBooked, TotalCost, BookingDate
                FROM Bookings 
                WHERE UserID = @userId AND BookingStatus = 'Confirmed'
                  AND JourneyDate >= @today
                ORDER BY JourneyDate ASC, DepartureTime ASC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@today", DateTime.Today);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine(" You have no confirmed bookings that can be cancelled.");
                            return;
                        }

                        Console.WriteLine("\n Your Confirmed Bookings (Future Travel Only):");
                        Console.WriteLine(new string('-', 80));

                        while (reader.Read())
                        {
                            int bookingId = reader.GetInt32(0);
                            string trainNumber = reader.GetString(1);
                            string trainName = reader.GetString(2);
                            string source = reader.GetString(3);
                            string destination = reader.GetString(4);
                            DateTime journeyDate = reader.GetDateTime(5);
                            TimeSpan departureTime = reader.GetTimeSpan(6);
                            TimeSpan arrivalTime = reader.GetTimeSpan(7);
                            string className = reader.GetString(8);
                            int seatsBooked = reader.GetInt32(9);
                            decimal totalCost = reader.GetDecimal(10);
                            DateTime bookingDate = reader.GetDateTime(11);

                            Console.WriteLine($"\n Booking ID: {bookingId}");
                            Console.WriteLine($" Train: {trainNumber} - {trainName}");
                            Console.WriteLine($" Route: {source} → {destination}");
                            Console.WriteLine($" Journey: {journeyDate:dddd, dd MMM yyyy}");
                            Console.WriteLine($" Time: {departureTime:hh\\:mm} → {arrivalTime:hh\\:mm}");
                            Console.WriteLine($" Class: {className} | Passengers: {seatsBooked}");
                            Console.WriteLine($" Total Cost: ₹{totalCost:F2}");
                            Console.WriteLine($" Booked: {bookingDate:dd MMM yyyy HH:mm}");
                        }
                    }
                }

                Console.WriteLine(new string('-', 80));
                Console.Write("Enter Booking ID to cancel (or 0 to go back): ");
                string input = Console.ReadLine()?.Trim();

                if (!int.TryParse(input, out int bookingIdToCancel) || bookingIdToCancel < 0)
                {
                    Console.WriteLine("Invalid Booking ID.");
                    return;
                }

                if (bookingIdToCancel == 0)
                {
                    Console.WriteLine("↩️ Cancellation aborted.");
                    return;
                }

                string validateQuery = @"
                SELECT TrainID, TrainNumber, TrainName, Source, Destination, 
                       JourneyDate, DepartureTime, ClassName, SeatsBooked, 
                       TotalCost, BookingStatus
                FROM Bookings 
                WHERE BookingID = @bookingId AND UserID = @userId";

                using (var validateCmd = new SqlCommand(validateQuery, conn))
                {
                    validateCmd.Parameters.AddWithValue("@bookingId", bookingIdToCancel);
                    validateCmd.Parameters.AddWithValue("@userId", userId);

                    using (var validateReader = validateCmd.ExecuteReader())
                    {
                        if (!validateReader.HasRows)
                        {
                            Console.WriteLine("Booking not found or doesn't belong to you.");
                            return;
                        }

                        validateReader.Read();
                        int trainId = validateReader.GetInt32(0);
                        string trainNumber = validateReader.GetString(1);
                        string trainName = validateReader.GetString(2);
                        string source = validateReader.GetString(3);
                        string destination = validateReader.GetString(4);
                        DateTime journeyDate = validateReader.GetDateTime(5);
                        TimeSpan departureTime = validateReader.GetTimeSpan(6);
                        string className = validateReader.GetString(7);
                        int seatsBooked = validateReader.GetInt32(8);
                        decimal totalCost = validateReader.GetDecimal(9);
                        string bookingStatus = validateReader.GetString(10);
                        validateReader.Close();

                        if (bookingStatus != "Confirmed")
                        {
                            Console.WriteLine("This booking is already cancelled or refunded.");
                            return;
                        }

                        if (journeyDate < DateTime.Today)
                        {
                            Console.WriteLine(" Cannot cancel booking for past travel dates.");
                            return;
                        }

                        DateTime departureDateTime = journeyDate.Date.Add(departureTime);
                        if (departureDateTime <= DateTime.Now.AddHours(2))
                        {
                            Console.WriteLine("Cannot cancel booking within 2 hours of departure time.");
                            return;
                        }

                        decimal refundPercentage = (departureDateTime >= DateTime.Now.AddHours(24)) ? 0.90m : 0.75m;
                        decimal refundAmount = Math.Round(totalCost * refundPercentage, 2);
                        decimal cancellationFee = totalCost - refundAmount;

                        Console.WriteLine("\n" + new string('=', 60));
                        Console.WriteLine("️ CANCELLATION CONFIRMATION");
                        Console.WriteLine(new string('=', 60));
                        Console.WriteLine($" Booking ID: {bookingIdToCancel}");
                        Console.WriteLine($" Train: {trainNumber} - {trainName}");
                        Console.WriteLine($" Route: {source} → {destination}");
                        Console.WriteLine($" Journey: {journeyDate:dddd, dd MMM yyyy}");
                        Console.WriteLine($" Departure: {departureTime:hh\\:mm}");
                        Console.WriteLine($" Class: {className} | Passengers: {seatsBooked}");
                        Console.WriteLine($" Original Amount: ₹{totalCost:F2}");
                        Console.WriteLine($" Cancellation Fee ({(100 - refundPercentage * 100):F0}%): ₹{cancellationFee:F2}");
                        Console.WriteLine($" Refund Amount: ₹{refundAmount:F2}");
                        Console.WriteLine(new string('=', 60));

                        Console.Write("  Are you sure you want to cancel this booking? (y/n): ");
                        string confirm = Console.ReadLine()?.Trim().ToLowerInvariant();
                        if (confirm != "y" && confirm != "yes")
                        {
                            Console.WriteLine("↩️ Cancellation aborted by user.");
                            return;
                        }

                        using (var transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                string cancelBookingSql = @"
                                UPDATE Bookings 
                                SET BookingStatus = 'Cancelled', 
                                    CancellationDate = @cancellationDate,
                                    RefundAmount = @refundAmount,
                                    CancellationFee = @cancellationFee
                                WHERE BookingID = @bookingId";

                                using (var cancelBooking = new SqlCommand(cancelBookingSql, conn, transaction))
                                {
                                    cancelBooking.Parameters.AddWithValue("@cancellationDate", DateTime.Now);
                                    cancelBooking.Parameters.AddWithValue("@refundAmount", refundAmount);
                                    cancelBooking.Parameters.AddWithValue("@cancellationFee", cancellationFee);
                                    cancelBooking.Parameters.AddWithValue("@bookingId", bookingIdToCancel);
                                    cancelBooking.ExecuteNonQuery();
                                }

                                string restoreSeatsSql = @"
                                UPDATE TrainClasses 
                                SET SeatsAvailable = SeatsAvailable + @seats
                                WHERE TrainID = @trainId AND ClassName = @className";

                                using (var restoreSeats = new SqlCommand(restoreSeatsSql, conn, transaction))
                                {
                                    restoreSeats.Parameters.AddWithValue("@seats", seatsBooked);
                                    restoreSeats.Parameters.AddWithValue("@trainId", trainId);
                                    restoreSeats.Parameters.AddWithValue("@className", className);
                                    restoreSeats.ExecuteNonQuery();
                                }

                                transaction.Commit();

                                Console.WriteLine("\n CANCELLATION SUCCESSFUL!");
                                Console.WriteLine($" Booking ID {bookingIdToCancel} has been cancelled.");
                                Console.WriteLine($" Refund of ₹{refundAmount:F2} will be processed within 5-7 business days.");
                                Console.WriteLine(" Cancellation confirmation will be sent via email.");
                                Console.WriteLine($"{seatsBooked} seats have been made available for other passengers.");
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                Console.WriteLine(" Cancellation failed: " + ex.Message);
                            }
                        }
                    }
                }
            }
        }
    }
}
