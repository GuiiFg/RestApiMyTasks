namespace RestApiMyTasks.Models.Users
{
    public class DeleteResponseModel
    {
        public DeleteResponseModel(int? statusCode, int? deletedBit, string? msg)
        {
            this.statusCode = statusCode;
            this.deletedBit = deletedBit;
            this.msg = msg;
        }

        public int? statusCode { get; set; }
        public int? deletedBit { get; set; }
        public string? msg { get; set; }
    }
}
