using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Entities;

namespace ToDoApp.Repository.Tasks
{
    public class ToDoRepository : IToDoRepository
    {
        // temporary storage list
        private static List<ToDoItem> data = new List<ToDoItem>();

        public void CreateToDo(ToDoItem toDo)
        {
            // add here the database logic
            data.Add(toDo);
        }

        public ToDoItem GetToDo(Guid id)
        {
            // add here the database logic
            return data.Where(x=>x.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<ToDoItem> GetToDoList()
        {
            // add here the database logic
            return data;
        }

        public void UpdateToDo(ToDoItem toDo)
        {
            // add here the database logic
        }
    }
}
