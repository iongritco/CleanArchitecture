using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ToDo.Application.ToDo.Queries
{
    public class GetToDoListQueryHandler : IRequestHandler<GetToDoListQuery, ToDoListViewModel>
    {
        public Task<ToDoListViewModel> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            var result = new ToDoListViewModel { ToDoList = new List<ToDoViewModel> { new ToDoViewModel { Description = "Create architecture" } } };
            return Task.FromResult(result);
        }
    }
}
