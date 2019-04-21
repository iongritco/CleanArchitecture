using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;

namespace ToDoApp.Application.ToDo.Commands.UpdateToDo
{
    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand>
    {
        private readonly IToDoRepository toDoRepository;

        public UpdateToDoCommandHandler(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }

        public Task<Unit> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = this.toDoRepository.GetToDo(request.Id);
            toDo.SetDescription(request.Description);
            toDo.SetStatus(request.Status);
            this.toDoRepository.UpdateToDo(toDo);
            return Unit.Task;
        }
    }
}
