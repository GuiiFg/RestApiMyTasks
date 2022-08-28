using Npgsql;
using RestApiMyTasks.Models.Tasks;
using RestApiMyTasks.Models.Database;
using System.Text.Json;

namespace RestApiMyTasks.Services
{
    public class TaskService
    {
        private PostgresConectionModel pgConect = new PostgresConectionModel("localhost", "mytasks_user", "23#5@4", "db_mytasks");

        public List<TaskModel> getTasksById(int id)
        {

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


                return tasksList;
            }
            catch (Exception exp)
            {

                return tasksList;
            }
        }

        public CreateTaskResponseModel createTask(CreateTaskRequestModel createRequest)
        {

            try
            {
                using var conection = new NpgsqlConnection(pgConect.getConectionString());
                conection.Open();

                var sql = $"INSERT INTO tb_tasks(id_user_int, description_str, done_bool) VALUES ({createRequest.id_user},'{createRequest.description}', {createRequest.done})";

                using var cmd = new NpgsqlCommand(sql, conection);

                cmd.ExecuteNonQuery();

                CreateTaskResponseModel createResponse = new CreateTaskResponseModel(200, 1, "Success");

                return createResponse;
            }
            catch (Exception exp)
            {
                CreateTaskResponseModel createResponse = new CreateTaskResponseModel(400, 0, exp.Message);

                return createResponse;
            }
        }

        public UpdateTaksResponseModel updateTask(UpdateTaskRequestModel updateRequest)
        {
            try
            {
                using var conection = new NpgsqlConnection(pgConect.getConectionString());
                conection.Open();

                var sql = $"UPDATE tb_tasks SET description_str = '{updateRequest.descreption}', done_bool = {updateRequest.done} WHERE id_task_int = {updateRequest.task_id}";

                using var cmd = new NpgsqlCommand(sql, conection);

                cmd.ExecuteNonQuery();

                UpdateTaksResponseModel createResponse = new UpdateTaksResponseModel(200, 1, "Success");

                return createResponse;
            }
            catch (Exception exp)
            {
                UpdateTaksResponseModel createResponse = new UpdateTaksResponseModel(400, 0, exp.Message);

                return createResponse;
            }
        }

        public void deleteTask(int task_id)
        {
            try
            {
                using var conection = new NpgsqlConnection(pgConect.getConectionString());
                conection.Open();

                var sql = $"DELETE FROM tb_tasks WHERE id_task_int = {task_id};";

                using var cmd = new NpgsqlCommand(sql, conection);

                cmd.ExecuteNonQuery();


            }
            catch (Exception exp)
            {
            }
        }
    }
}
