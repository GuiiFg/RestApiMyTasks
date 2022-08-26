namespace RestApiMyTasks.Models
{
    public class PostgresConectionModel
    {
        //"Host=localhost;Username=postgres;Password=s$cret;Database=testdb"

        public PostgresConectionModel(string host, string username, string password, string database)
        {
            this.database = database;
            this.host = host;
            this.username = username;
            this.password = password;
        }

        public string getConectionString()
        {
            return $"Host={host};Username={username};Password={password};Database={database}";
        }

        public string host { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public string database { set; get; }
    }
}
