using System;
using System.Collections.Generic;
using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Entities;

namespace ToDoApp.Repository.Tasks
{
    public class ToDoRepository : IToDoRepository
    {
        public void CreateToDo(ToDoItem toDo)
        {
            Console.WriteLine(toDo.Description);
            // add here the database logic
        }

        public IEnumerable<ToDoItem> GetToDoList()
        {
            // add here the database logic
            return new List<ToDoItem> { new ToDoItem { Description = "test" } };
        }
    }
}
