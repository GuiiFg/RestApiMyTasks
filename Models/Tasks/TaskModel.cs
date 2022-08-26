namespace RestApiMyTasks.Models.Tasks
{
    public class TaskModel
    {
        public TaskModel(int? id_task_int, string? description_str, bool? done_bool)
        {
            this.id_task_int = id_task_int;
            this.description_str = description_str;
            this.done_bool = done_bool;
        }
        public TaskModel() { }
        public int? id_task_int { get; set; }
        public string? description_str { get; set; }
        public bool? done_bool { get; set; }
    }
}
