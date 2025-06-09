namespace Database
{
    public interface IDatabase
    {
        public abstract int ExecuteQuery(string query);
        public abstract bool UpdateGame(int id,string title,double price);
    }
}
