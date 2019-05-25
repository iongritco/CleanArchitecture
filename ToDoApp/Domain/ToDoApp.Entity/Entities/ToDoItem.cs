using System;
using System.ComponentModel.DataAnnotations;
using ToDoApp.Entity.Enums;

namespace ToDoApp.Entity.Entities
{
    public class ToDoItem
    {
        public ToDoItem()
        {
        }

        public ToDoItem(string description)
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            Status = Status.ToDo;
            SetDescription(description);
        }

        [Key]
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedDate { get; private set; }
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
