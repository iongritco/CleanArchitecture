using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;

namespace ToDoApp.Application.ToDo.Commands.UpdateToDo
{
    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand>
    {
        private readonly IToDoCommandRepository commandRepository;
        private readonly IToDoQueryRepository queryRepository;

        public UpdateToDoCommandHandler(IToDoCommandRepository commandRepository, IToDoQueryRepository queryRepository)
        {
            this.commandRepository = commandRepository;
            this.queryRepository = queryRepository;
        }

        public async Task<Unit> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = await this.queryRepository.GetToDo(request.Id, request.Username);
            toDo.SetDescription(request.Description);
            toDo.SetStatus(request.Status);

            await this.commandRepository.UpdateToDo(toDo);

            return Unit.Value;
        }
    }
}
