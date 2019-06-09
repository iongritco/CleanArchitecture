using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ToDoApp.Application.Interfaces;

namespace ToDoApp.Application.User.Queries
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, string>
    {
        private readonly IIdentityService identityService;
        private readonly ITokenService tokenService;

        public GetTokenQueryHandler(IIdentityService identityService, ITokenService tokenService)
        {
            this.identityService = identityService;
            this.tokenService = tokenService;
        }

        public async Task<string> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            string token = null;

            var isValid = await identityService.Authenticate(request.Username, request.Password);
            if (isValid)
            {
                token = tokenService.GenerateToken(request.Username);
            }

            return token;
        }
    }
}
