using System.Threading;
using System.Threading.Tasks;

using MediatR;

using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Entities;

namespace ToDoApp.Application.ToDo.Commands.CreateTask
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand>
    {
        public CreateToDoCommandHandler(IToDoCommandRepository commandRepository)
        {
            this.commandRepository = commandRepository;
        }

        private readonly IToDoCommandRepository commandRepository;

        public async Task<Unit> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = new ToDoItem(request.Id, request.Description, request.Username);
            await commandRepository.CreateToDo(toDo);

            return Unit.Value;
        }
    }
}
