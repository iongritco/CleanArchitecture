using ToDoApp.Domain.Entities;

namespace ToDo.Application.ToDo.Queries
{
    public class ToDoViewModel
    {
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
