using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace Database
{
    public class SqlDatabase : IDatabase
    {
        public SqlDatabase(string serverName, string databaseName, string login, string password)
        {
            ServerName = serverName;
            DatabaseName = databaseName;
            Login = login;
            Password = password;
        }
        public SqlDatabase()
        {
        }
        public string ServerName { get; set; } = "mssql";
        public string DatabaseName { get; set; } = "ispp3104";
        public string Login { get; set; } = "ispp3104";
        public string Password { get; set; } = "3104";
        private string _сonnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new()
                {
                    DataSource = ServerName,
                    InitialCatalog = DatabaseName,
                    UserID = Login,
                    Password = Password,
                    TrustServerCertificate = true
                };
                return builder.ConnectionString;
            }
        }
        public List<Game> Games
        {
            get
            {
                using SqlConnection connection = new(_сonnectionString);
                connection.Open();

                string query = "SELECT * FROM GAME";
                SqlCommand command = new(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                List<Game> games = new();
                Game game;

                if (reader.HasRows)
                    while (reader.Read())
                    {
                        game = new();
                        game.Id = Convert.ToInt32(reader["Id"]);
                        game.Title = reader["Title"].ToString();
                        game.Price = Convert.ToDouble(reader["Price"]);
                        games.Add(game);
                    }
                return games;
            }
        }

        public int ExecuteQuery(string query)
        {
            using SqlConnection connection = new(_сonnectionString);
            connection.Open();

            SqlCommand command = new(query, connection);
            return command.ExecuteNonQuery();
        }

        public object GetScalarValue(string query)
        {
            using SqlConnection connection = new(_сonnectionString);
            connection.Open();

            SqlCommand command = new(query, connection);
            return command.ExecuteScalar();
        }

        public bool UpdateGame(int id, string title, double price)
        {
            using SqlConnection connection = new(_сonnectionString);
            connection.Open();

            string query = @$"UPDATE Game 
                            SET Title = '{title}',
                            Price = {price} 
                            WHERE Id = {id};";

            SqlCommand command = new(query, connection);
            return command.ExecuteNonQuery() == 1;
        }
    }
}
