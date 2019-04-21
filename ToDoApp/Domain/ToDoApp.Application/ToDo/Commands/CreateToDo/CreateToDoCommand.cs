using MediatR;
using System;

namespace ToDoApp.Application.ToDo.Commands.CreateTask
{
    public class CreateToDoCommand : IRequest
    {
        public string Description { get; set; }
    }
}
