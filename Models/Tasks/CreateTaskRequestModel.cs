namespace RestApiMyTasks.Models.Tasks
{
    public class CreateTaskRequestModel
    {
        public int? id_user { get; set; }
        public string? description { get; set; }
        public bool? done { get; set; }
    }
}
