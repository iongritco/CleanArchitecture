using System.Collections.Generic;

namespace ToDoApp.Application.ToDo.Queries
{
    public class ToDoListViewModel
    {
        public ToDoListViewModel()
        {
            ToDoList = new List<ToDoViewModel>();
        }

        public List<ToDoViewModel> ToDoList { get; set; }
    }
}
