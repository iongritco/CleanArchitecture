using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Entities;

namespace ToDoApp.Repository.ToDo
{
    public class ToDoRepository : IToDoRepository
    {
        public ToDoRepository(ToDoDataContext toDoDataContext)
        {
            this.toDoDataContext = toDoDataContext;
        }
        
        private readonly ToDoDataContext toDoDataContext;

        public async Task CreateToDo(ToDoItem toDo)
        {
            toDoDataContext.Add(toDo);
            await toDoDataContext.SaveChangesAsync();
        }

        public async Task<ToDoItem> GetToDo(Guid id, string username)
        {
            return await toDoDataContext.ToDoItems.Where(x=>x.Id.Equals(id) && x.Username.Equals(username)).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ToDoItem>> GetToDoList(string username)
        {
            return await toDoDataContext.ToDoItems.Where(x=>x.Username.Equals(username)).ToListAsync();
        }

        public async Task UpdateToDo(ToDoItem toDo)
        {
            toDoDataContext.Update(toDo);
            await toDoDataContext.SaveChangesAsync();
        }
    }
}
