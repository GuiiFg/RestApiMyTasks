using Microsoft.AspNetCore.Mvc;
using RestApiMyTasks.Models.Users;
using RestApiMyTasks.Services;

namespace RestApiMyTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/<UsersController>/5
        [HttpPost("login")]
        public LoginUserResponseModel Login([FromBody] LoginUserRequestModel loginRequest)
        {
            UserService userService = new UserService();

            LoginUserResponseModel response = userService.tryLoginUser(loginRequest);

            return response;
        }

        // POST api/<ValuesController>
        [HttpPost("createUser")]
        public CreateUserResponseModel Post([FromBody] CreateUserRequestModel createRequest)
        {
            UserService userService = new UserService();

            CreateUserResponseModel response = userService.tryCreateUser(createRequest);

            return response;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("delete/{id}")]
        public DeleteUserResponseModel Delete(int id)
        {
            UserService userService = new UserService();

            DeleteUserResponseModel response = userService.tryDeleteUser(id);

            return response;
        }
    }
}
