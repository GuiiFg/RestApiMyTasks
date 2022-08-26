using Microsoft.AspNetCore.Mvc;
using RestApiMyTasks.Models.Tasks;
using RestApiMyTasks.Services;

namespace RestApiMyTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public GetTasksResponseModel Get(int id)
        {
            TaskService taskService = new TaskService();

            GetTasksResponseModel response = taskService.getTasksById(id);

            return response;
        }
        

        // POST api/<TasksController>
        [HttpPost("createTask")]
        public CreateTaskResponseModel Post([FromBody] CreateTaskRequestModel createRequest)
        {
            TaskService taskService = new TaskService();

            CreateTaskResponseModel response = taskService.createTask(createRequest);

            return response;
        }

        // PUT api/<TasksController>/5
        [HttpPut("updateTaks")]
        public UpdateTaksResponseModel Put([FromBody] UpdateTaskRequestModel updateRequest)
        {
            TaskService taskService = new TaskService();

            UpdateTaksResponseModel response = taskService.updateTask(updateRequest);

            return response;
        }

        /*
        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
