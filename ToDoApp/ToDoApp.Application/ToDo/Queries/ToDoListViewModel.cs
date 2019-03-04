using System.Collections.Generic;

namespace ToDoApp.Application.ToDo.Queries
{
    public class ToDoListViewModel
    {
        public IEnumerable<ToDoViewModel> ToDoList { get; set; }
    }
}
