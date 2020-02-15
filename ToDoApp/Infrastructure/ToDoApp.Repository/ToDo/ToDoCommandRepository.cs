using System.Threading.Tasks;

using ToDoApp.Application.Interfaces;
using ToDoApp.Entity.Entities;

namespace ToDoApp.Repository.ToDo
{
    public class ToDoCommandRepository : IToDoCommandRepository
    {
        public ToDoCommandRepository(ToDoDataContext toDoDataContext)
        {
            this.toDoDataContext = toDoDataContext;
        }

        private readonly ToDoDataContext toDoDataContext;

        public async Task CreateToDo(ToDoItem toDo)
        {
            toDoDataContext.Add(toDo);
            await toDoDataContext.SaveChangesAsync();
        }

        public async Task UpdateToDo(ToDoItem toDo)
        {
            toDoDataContext.Update(toDo);
            await toDoDataContext.SaveChangesAsync();
        }
    }
}
