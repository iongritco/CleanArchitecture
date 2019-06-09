using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;

namespace ToDoApp.Application.User.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IIdentityService identityService;

        public RegisterUserCommandHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await identityService.RegisterUser(request.Email, request.Password);

            return Unit.Value;
        }
    }
}
