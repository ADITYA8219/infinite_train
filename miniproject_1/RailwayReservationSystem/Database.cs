using System.Data.SqlClient;

namespace RailwayReservationSystem
{
    public static class Database
    {
        private static string connectionString = "Data Source=ICS-LT-1QQ0LQ3\\SQLEXPRESS;Initial Catalog=RailwayDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
