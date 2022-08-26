using Npgsql;
using RestApiMyTasks.Models.Users;
using System.Text.Json;

namespace RestApiMyTasks.Services
{
    public class UserService
    {
        public string tryLoginUser(LoginRequestModel loginRequest)
        {
            PostgresConectionModel pgConect = new PostgresConectionModel("localhost", "mytasks_user", "23#5@4", "db_mytasks");

            try
            {
                using var conection = new NpgsqlConnection(pgConect.getConectionString());
                conection.Open();

                var sql = $"SELECT * FROM tb_users WHERE email_str = '{loginRequest.email}'";

                using var cmd = new NpgsqlCommand(sql, conection);

                using NpgsqlDataReader readed = cmd.ExecuteReader();

                UserModel user = new UserModel();

                while (readed.Read())
                {
                    user = new UserModel(readed.GetInt32(0), readed.GetString(1), readed.GetString(2));
                }

                if (user.email_str != null)
                {
                    if (user.senha_str == loginRequest.senha)
                    {
                        LoginResponseModel loginResponse = new LoginResponseModel(200, user.id_int, "Success");

                        return JsonSerializer.Serialize(loginResponse);
                    }
                    else
                    {
                        LoginResponseModel loginResponse = new LoginResponseModel(401, 0, "Unauthorized");

                        return JsonSerializer.Serialize(loginResponse);
                    }
                }
                else
                {
                    LoginResponseModel loginResponse = new LoginResponseModel(404, 0, "Not Found");

                    return JsonSerializer.Serialize(loginResponse);
                }
            }
            catch (Exception exp)
            {
                LoginResponseModel loginResponse = new LoginResponseModel(500, 0, exp.Message);

                return JsonSerializer.Serialize(loginResponse);
            }
        }

        public string tryCreateUser(CreateRequestModel createRequest)
        {
            PostgresConectionModel pgConect = new PostgresConectionModel("localhost", "mytasks_user", "23#5@4", "db_mytasks");

            try
            {
                using var conection = new NpgsqlConnection(pgConect.getConectionString());
                conection.Open();

                var sql = $"INSERT INTO tb_users(email_str,senha_str) VALUES ('{createRequest.email}', '{createRequest.senha}')";

                using var cmd = new NpgsqlCommand(sql, conection);

                cmd.ExecuteNonQuery();

                CreateResponseModel createResponse = new CreateResponseModel(200, 1, "User Created");

                return JsonSerializer.Serialize(createResponse);
            }
            catch (Exception exp)
            {
                CreateResponseModel createResponse = new CreateResponseModel(400, 0, exp.Message);

                return JsonSerializer.Serialize(createResponse);
            }
        }

        public string tryDeleteUser(int id)
        {
            PostgresConectionModel pgConect = new PostgresConectionModel("localhost", "mytasks_user", "23#5@4", "db_mytasks");

            try
            {
                using var conection = new NpgsqlConnection(pgConect.getConectionString());
                conection.Open();

                using var cmd = new NpgsqlCommand();

                cmd.Connection = conection;

                cmd.CommandText = "DELETE FROM tb_tasks WHERE id_user_int = " + id.ToString() + ";";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM tb_users WHERE id_int = " + id.ToString() + ";";
                cmd.ExecuteNonQuery();

                DeleteResponseModel deleteResponse = new DeleteResponseModel(200, 1, "User Deleted");

                return JsonSerializer.Serialize(deleteResponse);
            }
            catch (Exception exp)
            {
                DeleteResponseModel deleteResponse = new DeleteResponseModel(400, 0, exp.Message);

                return JsonSerializer.Serialize(deleteResponse);
            }
        }
    }
}
