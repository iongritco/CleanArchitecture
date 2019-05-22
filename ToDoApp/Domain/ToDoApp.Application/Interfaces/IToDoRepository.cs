using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Entity.Entities;

namespace ToDoApp.Application.Interfaces
{
    public interface IToDoRepository
    {
        Task CreateToDo(ToDoItem toDo);

        Task<IEnumerable<ToDoItem>> GetToDoList();

        Task UpdateToDo(ToDoItem toDo);

        Task<ToDoItem> GetToDo(Guid id);
    }
}
