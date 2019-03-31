using System;
using ToDoApp.Entity.Enums;

namespace ToDoApp.Entity.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public Status Status { get; set; }
    }
}
