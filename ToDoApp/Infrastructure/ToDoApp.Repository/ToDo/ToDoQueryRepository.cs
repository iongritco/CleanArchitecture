using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Entities;

namespace ToDoApp.Repository.ToDo
{
    public class ToDoQueryRepository : IToDoQueryRepository
    {
        public ToDoQueryRepository(ToDoDataContext toDoDataContext)
        {
            this.toDoDataContext = toDoDataContext;
            this.toDoDataContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        private readonly ToDoDataContext toDoDataContext;

        public async Task<ToDoItem> GetToDo(Guid id, string username)
        {
            return await toDoDataContext.ToDoItems.Where(x => x.Id.Equals(id) && x.Username.Equals(username)).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ToDoItem>> GetToDoList(string username)
        {
            return await toDoDataContext.ToDoItems.Where(x => x.Username.Equals(username)).ToListAsync();
        }
    }
}
