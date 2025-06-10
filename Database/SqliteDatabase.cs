using Microsoft.Data.Sqlite;
using System.Runtime.CompilerServices;

namespace Database
{
    public class SqliteDatabase : IDatabase
    {
        public SqliteDatabase(string fileName) 
        { 
            FileName = fileName;
        }
        public SqliteDatabase()
        {
        }
        public string FileName { get; set; } = "testdb31.sqlite";
        private string _connectionString
        {
            get
            {
                SqliteConnectionStringBuilder builder = new()
                {
                    DataSource = FileName
                };
                return builder.ConnectionString;
            }
        }
        public List<Game> Games
        {
            get
            {
                using SqliteConnection connection = new(_connectionString);
                connection.Open();

                string query = "SELECT * FROM GAME";
                SqliteCommand command = new(query, connection);
                SqliteDataReader reader = command.ExecuteReader();

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
        public object GetScalarValue(string query)
        {
            using SqliteConnection connection = new(_connectionString);
            connection.Open();

            SqliteCommand command = new(query, connection);
            return command.ExecuteScalar();
        }

        public int ExecuteQuery(string query)
        {
            using SqliteConnection connection = new(_connectionString);
            connection.Open();

            SqliteCommand command = new(query, connection);
            return command.ExecuteNonQuery();
        }

        public bool UpdateGame(int id, string title, double price)
        {
            using SqliteConnection connection = new(_connectionString);
            connection.Open();

            string query = @$"UPDATE Game 
                            SET Title = '{title}',
                            Price = {price} 
                            WHERE Id = {id};";

            SqliteCommand command = new(query, connection);
            return command.ExecuteNonQuery() == 1;
        }
    }
}
