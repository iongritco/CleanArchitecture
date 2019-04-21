using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Enums;

namespace ToDoApp.Application.ToDo.Commands.DeleteToDo
{
    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand>
    {
        private readonly IToDoRepository toDoRepository;

        public DeleteToDoCommandHandler(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }

        public Task<Unit> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = this.toDoRepository.GetToDo(request.Id);
            toDo.SetStatus(Status.Deleted);
            this.toDoRepository.UpdateToDo(toDo);
            return Unit.Task;
        }
    }
}
