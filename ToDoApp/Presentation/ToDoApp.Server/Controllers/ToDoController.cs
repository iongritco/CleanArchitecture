using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Application.ToDo.Commands.CreateTask;
using ToDoApp.Application.ToDo.Commands.DeleteToDo;
using ToDoApp.Application.ToDo.Commands.UpdateToDo;
using ToDoApp.Application.ToDo.Queries;

namespace ToDoApp.Server.Controllers
{
    [Route("api/todo")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator mediator;

        public ToDoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetToDoList()
        {
            var result = await mediator.Send(new GetToDoListQuery(User.Identity.Name));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDo(CreateToDoCommand command)
        {
            command.Username = User.Identity.Name;
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToDo(UpdateToDoCommand command)
        {
            command.Username = User.Identity.Name;
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteToDo(DeleteToDoCommand command)
        {
            command.Username = User.Identity.Name;
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}