namespace RestApiMyTasks.Models.Users
{
    public class UserModel
    {
        public UserModel(int id_int, string email_str, string senha_str)
        {
            this.id_int = id_int;
            this.email_str = email_str;
            this.senha_str = senha_str;
        }
        public UserModel() { }
        public int? id_int { get; set; }
        public string? email_str { get; set; }
        public string? senha_str { get; set; }
    }
}
