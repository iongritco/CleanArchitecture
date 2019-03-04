using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ToDo.Application.ToDo.Commands
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand>
    {
        public Task<Unit> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}
