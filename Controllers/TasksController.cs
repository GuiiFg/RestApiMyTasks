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
        [HttpGet("{idCliente}")]
        public List<TaskModel> Get(int idCliente)
        {
            TaskService taskService = new TaskService();

            List<TaskModel> response = taskService.getTasksById(idCliente);

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

        // DELETE api/<TasksController>/5
        [HttpDelete("delete/{id_task}")]
        public void Delete(int id_task)
        {
            TaskService taskService = new TaskService();
            taskService.deleteTask(id_task);
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
