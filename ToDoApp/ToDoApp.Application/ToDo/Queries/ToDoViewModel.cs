using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.ToDo.Queries
{
    public class ToDoViewModel
    {
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
