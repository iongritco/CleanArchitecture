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

        public async Task<Unit> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = await this.toDoRepository.GetToDo(request.Id);
            toDo.SetStatus(Status.Deleted);

            await this.toDoRepository.UpdateToDo(toDo);

            return Unit.Value;
        }
    }
}
