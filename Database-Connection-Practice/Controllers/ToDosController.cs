using Database_Connection_Practice.DTOs;
using Database_Connection_Practice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Database_Connection_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController(IToDoService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GetToDoResponse>>> GetAllTodo()
        => Ok(await service.GetAllToDosAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<GetToDoResponse>> GetTodo(int id) {
            var todo = await service.GetToDoById(id);
            return todo is null ? NotFound("Todo Not Found With Given Id") : Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<GetToDoResponse>> CreateToDo(CreateToDoRequest request) { 
            var newTodo = await service.CreateToDoAsync(request);
            return CreatedAtAction(nameof(GetTodo), new { id= newTodo.Id }, newTodo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodo(int id, UpdateToDoRequest request) 
        {
            var updated = await service.UpdateToDoAsync(id, request);
            return updated ? NoContent() : NotFound("Todo Not Found With Given Id");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id) {
            var deleted = await service.DeleteToDoAsync(id);
            return deleted is true ? NoContent() : NotFound("Todo Not Found With Given Id");
        }
    }
}
