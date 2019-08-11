using System;
using MediatR;

namespace ToDoApp.Application.ToDo.Commands.CreateTask
{
    public class CreateToDoCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Username { get; set; }
    }
}
