using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;

namespace ToDoApp.Application.ToDo.Queries
{
    public class GetTaskListQueryHandler : IRequestHandler<GetToDoListQuery, ToDoListViewModel>
    {
        private readonly IToDoRepository toDoRepository;

        public GetTaskListQueryHandler(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }

        public async Task<ToDoListViewModel> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            var toDoList = await this.toDoRepository.GetToDoList();
            var result = new ToDoListViewModel();
            foreach (var item in toDoList)
            {
                result.ToDoList.Add(new ToDoViewModel { Id = item.Id, Status = item.Status, Description = item.Description });
            }

            return result;
        }
    }
}
