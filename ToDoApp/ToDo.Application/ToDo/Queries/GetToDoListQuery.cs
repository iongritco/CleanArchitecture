using MediatR;

namespace ToDo.Application.ToDo.Queries
{
    public class GetToDoListQuery : IRequest<ToDoListViewModel>
    {
    }
}
