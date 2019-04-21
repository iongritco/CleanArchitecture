using System;
using ToDoApp.Entity.Enums;

namespace ToDoApp.Entity.Entities
{
    public class ToDoItem
    {
        public ToDoItem(string description)
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            Status = Status.ToDo;
            SetDescription(description);
        }

        public Guid Id { get; }
        public string Description { get; private set; }
        public DateTime CreatedDate { get; }
        public DateTime? CompletedDate { get; private set; }
        public Status Status { get; private set; }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            Description = description;
        }

        public void SetStatus(Status status)
        {
            if (status == Status.None)
            {
                throw new ArgumentOutOfRangeException(nameof(status));
            }

            if (status == Status.Completed)
            {
                CompletedDate = DateTime.UtcNow;
            }

            Status = status;
        }
    }
}
