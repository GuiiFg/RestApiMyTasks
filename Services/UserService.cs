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
            return "";
        }
    }
}
