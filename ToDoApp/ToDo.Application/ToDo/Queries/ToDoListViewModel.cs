using System.Collections.Generic;

namespace ToDo.Application.ToDo.Queries
{
    public class ToDoListViewModel
    {
        public IEnumerable<ToDoViewModel> ToDoList { get; set; }
    }
}
