using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.ToDo.Events;

namespace ToDoApp.Application.ToDo.Commands.UpdateToDo
{
    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand>
    {
        private readonly IToDoCommandRepository commandRepository;
        private readonly IToDoQueryRepository queryRepository;
        private readonly IMediator mediator;

        public UpdateToDoCommandHandler(
            IToDoCommandRepository commandRepository, 
            IToDoQueryRepository queryRepository, 
            IMediator mediator)
        {
            this.commandRepository = commandRepository;
            this.queryRepository = queryRepository;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = await this.queryRepository.GetToDo(request.Id, request.Username);
            toDo.SetDescription(request.Description);
            toDo.SetStatus(request.Status);

            await this.commandRepository.UpdateToDo(toDo);
            await mediator.Publish(new TaskUpdatedEvent(toDo.Username, toDo.Description, toDo.Status));

            return Unit.Value;
        }
    }
}
