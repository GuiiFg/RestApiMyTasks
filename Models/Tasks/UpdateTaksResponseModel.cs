namespace RestApiMyTasks.Models.Tasks
{
    public class UpdateTaksResponseModel
    {
        public UpdateTaksResponseModel(int? statusCode, int? updatedBit, string? msg)
        {
            this.statusCode = statusCode;
            this.updatedBit = updatedBit;
            this.msg = msg;
        }

        public int? statusCode { get; set; }
        public int? updatedBit { get; set; }
        public string? msg { get; set; }
    }
}
