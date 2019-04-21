using System;
using System.Collections.Generic;
using ToDoApp.Entity.Entities;

namespace ToDoApp.Application.Interfaces
{
    public interface IToDoRepository
    {
        void CreateToDo(ToDoItem toDo);

        IEnumerable<ToDoItem> GetToDoList();

        void UpdateToDo(ToDoItem toDo);

        ToDoItem GetToDo(Guid id);
    }
}
