namespace RestApiMyTasks.Models.Tasks
{
    public class UpdateTaskRequestModel
    {
        public int? task_id { get; set; }
        public string? descreption { get; set; }
        public bool? done { get; set; }
    }
}
