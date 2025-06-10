using Microsoft.Data.Sqlite;

namespace Database
{
    public class SqliteDatabase : IDatabase
    {
        public string FileName { get; set; }

        private readonly string _connectionString;

        public SqliteDatabase(string fileName)
        {
            FileName = fileName;
            SqliteConnectionStringBuilder builder = new()
            {
                DataSource = FileName
            };
            _connectionString = builder.ConnectionString;
        }

        public SqliteDatabase() : this("testdb31.sqlite")
        {
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

        public void InsertGame(string title, double price, int publicationYear)
        {
            using SqliteConnection connection = new(_connectionString);
            connection.Open();

            string query = @$"INSERT INTO Game(Title, Price, PublicationYear) 
                            VALUES (@title, @price, @publicationYear);";

            SqliteCommand command = new(query, connection);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@publicationYear", publicationYear);

            command.ExecuteNonQuery();
        }
    }
}
