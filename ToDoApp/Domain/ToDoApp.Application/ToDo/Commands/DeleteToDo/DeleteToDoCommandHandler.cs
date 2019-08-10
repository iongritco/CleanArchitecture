using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Enums;

namespace ToDoApp.Application.ToDo.Commands.DeleteToDo
{
    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand>
    {
        private readonly IToDoCommandRepository commandRepository;
        private readonly IToDoQueryRepository queryRepository;

        public DeleteToDoCommandHandler(IToDoCommandRepository commandRepository, IToDoQueryRepository queryRepository)
        {
            this.commandRepository = commandRepository;
            this.queryRepository = queryRepository;
        }

        public async Task<Unit> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = await this.queryRepository.GetToDo(request.Id, request.Username);
            toDo.SetStatus(Status.Deleted);

            await this.commandRepository.UpdateToDo(toDo);

            return Unit.Value;
        }
    }
}
