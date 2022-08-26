namespace RestApiMyTasks.Models.Tasks
{
    public class GetTasksResponseModel
    {
        public GetTasksResponseModel(int? statusCode, List<TaskModel>? taskList, string? msg)
        {
            this.statusCode = statusCode;
            this.taskList = taskList;
            this.msg = msg;
        }

        public int? statusCode { get; set; }
        public List<TaskModel>? taskList { get; set; }
        public string? msg { get; set; }
    }
}
