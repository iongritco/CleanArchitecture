using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApp.Application.ToDo.Commands.CreateTask;
using ToDoApp.Application.ToDo.Queries;

namespace ToDoApp.Server.Controllers
{
    public class ToDoController : ControllerBase
    {
        public ToDoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        private readonly IMediator mediator;

        [HttpPost]
        public async Task<IActionResult> CreateToDo([FromBody]CreateToDoCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetToDoList()
        {
            var result = await mediator.Send(new GetToDoListQuery());
            return Ok(result);
        }
    }
}