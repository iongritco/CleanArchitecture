using MediatR;
using System.Collections.Generic;
using ToDoApp.Entity.Entities;

namespace ToDoApp.Application.ToDo.Queries
{
    public class GetToDoListQuery : IRequest<List<ToDoItem>>
    {
        public GetToDoListQuery(string username)
        {
            Username = username;
        }

        public string Username { get; private set; }
    }
}
