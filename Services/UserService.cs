using Npgsql;
using RestApiMyTasks.Models.Database;
using RestApiMyTasks.Models.Users;
using System.Text.Json;

namespace RestApiMyTasks.Services
{
    public class UserService
    {
        public LoginUserResponseModel tryLoginUser(LoginUserRequestModel loginRequest)
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
                        LoginUserResponseModel loginResponse = new LoginUserResponseModel(200, user.id_int, "Success");

                        return loginResponse;
                    }
                    else
                    {
                        LoginUserResponseModel loginResponse = new LoginUserResponseModel(401, 0, "Unauthorized");

                        return loginResponse;
                    }
                }
                else
                {
                    LoginUserResponseModel loginResponse = new LoginUserResponseModel(404, 0, "Not Found");

                    return loginResponse;
                }
            }
            catch (Exception exp)
            {
                LoginUserResponseModel loginResponse = new LoginUserResponseModel(500, 0, exp.Message);

                return loginResponse;
            }
        }

        public CreateUserResponseModel tryCreateUser(CreateUserRequestModel createRequest)
        {
            PostgresConectionModel pgConect = new PostgresConectionModel("localhost", "mytasks_user", "23#5@4", "db_mytasks");

            try
            {
                using var conection = new NpgsqlConnection(pgConect.getConectionString());
                conection.Open();

                var sql = $"INSERT INTO tb_users(email_str,senha_str) VALUES ('{createRequest.email}', '{createRequest.senha}')";

                using var cmd = new NpgsqlCommand(sql, conection);

                cmd.ExecuteNonQuery();

                CreateUserResponseModel createResponse = new CreateUserResponseModel(200, 1, "User Created");

                return createResponse;
            }
            catch (Exception exp)
            {
                CreateUserResponseModel createResponse = new CreateUserResponseModel(400, 0, exp.Message);

                return createResponse;
            }
        }

        public DeleteUserResponseModel tryDeleteUser(int id)
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

                DeleteUserResponseModel deleteResponse = new DeleteUserResponseModel(200, 1, "User Deleted");

                return deleteResponse;
            }
            catch (Exception exp)
            {
                DeleteUserResponseModel deleteResponse = new DeleteUserResponseModel(400, 0, exp.Message);

                return deleteResponse;
            }
        }
    }
}
