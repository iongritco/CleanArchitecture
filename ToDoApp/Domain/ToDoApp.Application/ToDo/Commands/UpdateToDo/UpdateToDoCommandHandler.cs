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

        public async Task<Unit> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = await this.toDoRepository.GetToDo(request.Id);
            toDo.SetDescription(request.Description);
            toDo.SetStatus(request.Status);

            await this.toDoRepository.UpdateToDo(toDo);

            return Unit.Value;
        }
    }
}
