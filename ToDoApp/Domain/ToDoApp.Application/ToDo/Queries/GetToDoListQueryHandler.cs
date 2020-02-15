using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Entities;
using ToDoApp.Entity.Enums;

namespace ToDoApp.Application.ToDo.Queries
{
    public class GetTaskListQueryHandler : IRequestHandler<GetToDoListQuery, List<ToDoItem>>
    {
        private readonly IToDoQueryRepository queryRepository;

        public GetTaskListQueryHandler(IToDoQueryRepository toDoRepository)
        {
            this.queryRepository = toDoRepository;
        }

        public async Task<List<ToDoItem>> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            var toDoList = await this.queryRepository.GetToDoList(request.Username);
            return toDoList.Where(x => x.Status != Status.Deleted).ToList();
        }
    }
}
