using Npgsql;
using RestApiMyTasks.Models.Tasks;
using RestApiMyTasks.Models.Database;
using System.Text.Json;

namespace RestApiMyTasks.Services
{
    public class TaskService
    {
        public string getTasksById(int id)
        {
            PostgresConectionModel pgConect = new PostgresConectionModel("localhost", "mytasks_user", "23#5@4", "db_mytasks");

            List<TaskModel> tasksList = new List<TaskModel>();

            try
            {
                using var conection = new NpgsqlConnection(pgConect.getConectionString());
                conection.Open();

                var sql = $"SELECT id_task_int, description_str, done_bool FROM tb_tasks WHERE id_user_int = " + id.ToString() + ";";

                using var cmd = new NpgsqlCommand(sql, conection);

                using NpgsqlDataReader readed = cmd.ExecuteReader();

                while (readed.Read())
                {
                    TaskModel newTask = new TaskModel(readed.GetInt32(0), readed.GetString(1), readed.GetBoolean(2));
                    tasksList.Add(newTask);
                }

                GetTasksResponseModel getResponse = new GetTasksResponseModel(200, tasksList, "Success");

                return JsonSerializer.Serialize(getResponse);
            }
            catch (Exception exp)
            {
                GetTasksResponseModel getResponse = new GetTasksResponseModel(400, tasksList, exp.Message);

                return JsonSerializer.Serialize(getResponse);
            }
        }

        public string createTask(CreateTaskRequestModel createRequest)
        {
            PostgresConectionModel pgConect = new PostgresConectionModel("localhost", "mytasks_user", "23#5@4", "db_mytasks");

            try
            {
                using var conection = new NpgsqlConnection(pgConect.getConectionString());
                conection.Open();

                var sql = $"INSERT INTO tb_tasks(id_user_int, description_str, done_bool) VALUES ({createRequest.id_user},'{createRequest.description}', {createRequest.done})";

                using var cmd = new NpgsqlCommand(sql, conection);

                cmd.ExecuteNonQuery();

                CreateTaskResponseModel createResponse = new CreateTaskResponseModel(200, 1, "Success");

                return JsonSerializer.Serialize(createResponse);
            }
            catch (Exception exp)
            {
                CreateTaskResponseModel createResponse = new CreateTaskResponseModel(400, 0, exp.Message);

                return JsonSerializer.Serialize(createResponse);
            }
        }
    }
}
