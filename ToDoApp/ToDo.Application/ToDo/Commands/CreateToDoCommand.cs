using MediatR;

namespace ToDo.Application.ToDo.Commands
{
    public class CreateToDoCommand : IRequest
    {
        public string Description { get; set; }
    }
}
