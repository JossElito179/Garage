using Npgsql;

namespace Garage.Models
{
    public class ConnectionBase
    {
        internal NpgsqlConnection giveConnection()
        {
            string connectionString = "Server=localhost;Port=5432;Database=Garage;User Id=postgres;Password=noob;";

            NpgsqlConnection connection = new (connectionString);
            connection.Open();

            return connection;
        }

    }
}