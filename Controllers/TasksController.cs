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
        public string Get(int id)
        {
            TaskService taskService = new TaskService();

            string response = taskService.getTasksById(id);

            return response;
        }
        

        // POST api/<TasksController>
        [HttpPost("createTask")]
        public string Post([FromBody] CreateTaskRequestModel createRequest)
        {
            TaskService taskService = new TaskService();

            string response = taskService.createTask(createRequest);

            return response;
        }

        /*
        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
