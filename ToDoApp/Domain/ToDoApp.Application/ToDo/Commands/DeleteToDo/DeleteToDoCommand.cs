using System;

using MediatR;

namespace ToDoApp.Application.ToDo.Commands.DeleteToDo
{
    public class DeleteToDoCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Username { get; set; }
    }
}
