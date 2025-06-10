using Microsoft.Data.SqlClient;

namespace Database
{
    public class SqlDatabase : IDatabase
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        private readonly string _connectionString;

        public SqlDatabase(string serverName, string databaseName, string login, string password)
        {
            ServerName = serverName;
            DatabaseName = databaseName;
            Login = login;
            Password = password;

            SqlConnectionStringBuilder builder = new()
            {
                DataSource = ServerName,
                InitialCatalog = DatabaseName,
                UserID = Login,
                Password = Password,
                TrustServerCertificate = true
            };
            _connectionString = builder.ConnectionString;
        }

        public SqlDatabase() : this("mssql", "ispp3104", "ispp3104", "3104")
        {
        }

        public int ExecuteQuery(string query)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            SqlCommand command = new(query, connection);
            return command.ExecuteNonQuery();
        }

        public bool UpdateGame(int id, string title, double price)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            string query = @$"UPDATE Game 
                            SET Title = '{title}',
                            Price = {price} 
                            WHERE Id = {id};";

            SqlCommand command = new(query, connection);
            return command.ExecuteNonQuery() == 1;
        }

        public void InsertGame(string title, double price, int publicationYear)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            string query = @$"INSERT INTO Game(Title, Price, PublicationYear) 
                            VALUES (@title, @price, @publicationYear);";

            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@publicationYear", publicationYear);

            command.ExecuteNonQuery();
        }
    }
}