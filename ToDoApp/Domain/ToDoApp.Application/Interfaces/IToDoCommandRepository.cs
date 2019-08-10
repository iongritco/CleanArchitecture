using System.Threading.Tasks;
using ToDoApp.Entity.Entities;

namespace ToDoApp.Application.Interfaces
{
    public interface IToDoCommandRepository
    {
        Task CreateToDo(ToDoItem toDo);

        Task UpdateToDo(ToDoItem toDo);
    }
}
