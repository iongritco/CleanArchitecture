using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApp.Application.ToDo.Commands;
using ToDoApp.Application.ToDo.Queries;

namespace ToDoApp.Server.Controllers
{
    public class ToDoController : ControllerBase
    {
        public ToDoController(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }

        [HttpPost]
        public async Task<IActionResult> CreateToDo(CreateToDoCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetToDoList(GetToDoListQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}