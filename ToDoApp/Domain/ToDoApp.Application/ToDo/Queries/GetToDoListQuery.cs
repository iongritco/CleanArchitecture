using MediatR;

namespace ToDoApp.Application.ToDo.Queries
{
    public class GetToDoListQuery : IRequest<ToDoListViewModel>
    {
    }
}
