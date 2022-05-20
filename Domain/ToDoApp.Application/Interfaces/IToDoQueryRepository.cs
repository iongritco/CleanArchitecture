
using ToDoApp.Entity.Entities;

namespace ToDoApp.Application.Interfaces
{
    public interface IToDoQueryRepository
    {
        Task<IEnumerable<ToDoItem>> GetToDoList(string username);

        Task<ToDoItem> GetToDo(Guid id, string username);
    }
}
