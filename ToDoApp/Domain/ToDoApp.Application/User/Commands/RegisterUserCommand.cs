using MediatR;

namespace ToDoApp.Application.User.Commands
{
    public class RegisterUserCommand : IRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
