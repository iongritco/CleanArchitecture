using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Entities;
using ToDoApp.Entity.Enums;

namespace ToDoApp.Application.ToDo.Queries
{
    public class GetTaskListQueryHandler : IRequestHandler<GetToDoListQuery, List<ToDoItem>>
    {
        private readonly IToDoRepository toDoRepository;

        public GetTaskListQueryHandler(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }

        public async Task<List<ToDoItem>> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            var toDoList = await this.toDoRepository.GetToDoList(request.Username);
            return toDoList.Where(x => x.Status != Status.Deleted).ToList();
        }
    }
}
