using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Generics;

namespace ToDoApp.Application.User.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result>
    {
        private readonly IIdentityService identityService;

        public RegisterUserCommandHandler(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await identityService.RegisterUser(request.Email, request.Password);

            return result;
        }
    }
}
