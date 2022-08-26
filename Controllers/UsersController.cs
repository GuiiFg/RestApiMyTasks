using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestApiMyTasks.Models;
using System.Runtime.Intrinsics.Arm;

namespace RestApiMyTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/<UsersController>/5
        [HttpGet("login/{email}/{senha}")]
        public string Login(string email, string senha)
        {
            PostgresConectionModel pgConect = new PostgresConectionModel("localhost", "mytasks_user", "23#5@4", "db_mytasks");

            try
            {
                using var conection = new NpgsqlConnection(pgConect.getConectionString());
                conection.Open();

                var sql = $"SELECT * FROM tb_users WHERE email_str = '{email}'";

                using var cmd = new NpgsqlCommand(sql, conection);

                using NpgsqlDataReader readed = cmd.ExecuteReader();

                UserModel user = new UserModel();

                while (readed.Read())
                {
                    user = new UserModel(readed.GetInt32(0), readed.GetString(1), readed.GetString(2));
                }

                if (user.email_str != null)
                {
                    if (user.senha_str == senha)
                    {
                        return "{\"status\": 200, \"user_id\": " + user.id_int.ToString() + ", \"msg\": \"Success\" }";
                    }
                    else
                    {
                        return "{\"status\": 401, \"user_id\": , \"msg\": \"Unauthorized\" }";
                    }
                }
                else
                {
                    return "{\"status\": 404, \"user_id\": , \"msg\": \"Not Found\" }";
                }
            }
            catch (Exception exp)
            {
                return "{\"status\": 500, \"msg\": \"" + exp.Message + "\" }";
            }
        }

        /*
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
