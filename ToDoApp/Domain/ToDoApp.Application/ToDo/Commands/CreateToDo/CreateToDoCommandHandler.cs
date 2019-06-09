using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Entities;

namespace ToDoApp.Application.ToDo.Commands.CreateTask
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand>
    {
        public CreateToDoCommandHandler(IToDoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        private readonly IToDoRepository todoRepository;

        public async Task<Unit> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = new ToDoItem(request.Description, request.Username);
            await todoRepository.CreateToDo(toDo);

            return Unit.Value;
        }
    }
}
