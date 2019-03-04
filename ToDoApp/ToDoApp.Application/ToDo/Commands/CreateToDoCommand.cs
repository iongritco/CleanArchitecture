using MediatR;

namespace ToDoApp.Application.ToDo.Commands
{
    public class CreateToDoCommand : IRequest
    {
        public string Description { get; set; }
    }
}
