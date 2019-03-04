using System;

namespace ToDoApp.Domain.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public Status Status { get; set; }
    }
}
