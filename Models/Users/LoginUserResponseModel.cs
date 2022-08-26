namespace RestApiMyTasks.Models.Users
{
    public class LoginUserResponseModel
    {
        public LoginUserResponseModel(int? statusCode, int? userId, string? msg)
        {
            this.statusCode = statusCode;
            this.userId = userId;
            this.msg = msg;
        }

        public int? statusCode { get; set; }
        public int? userId { get; set; }
        public string? msg { get; set; }
    }
}
