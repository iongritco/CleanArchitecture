using System.Threading;
using System.Threading.Tasks;

using MediatR;

using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Entities;

namespace ToDoApp.Application.ToDo.Commands.CreateToDo
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand>
    {
        private readonly IToDoCommandRepository _commandRepository;

        public CreateToDoCommandHandler(IToDoCommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<Unit> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = new ToDoItem(request.Id, request.Description, request.Username);
            await _commandRepository.CreateToDo(toDo);

            return Unit.Value;
        }
    }
}
