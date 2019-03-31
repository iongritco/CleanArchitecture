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

        public Task<Unit> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            todoRepository.CreateToDo(new ToDoItem { Description = request.Description });
            return Unit.Task;
        }
    }
}
