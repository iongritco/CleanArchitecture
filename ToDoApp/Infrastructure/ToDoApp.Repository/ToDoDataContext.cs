using Microsoft.EntityFrameworkCore;
using ToDoApp.Entity.Entities;

namespace ToDoApp.Repository
{
    public class ToDoDataContext : DbContext
    {
        public ToDoDataContext(DbContextOptions<ToDoDataContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>().HasData(
                new ToDoItem("Do it!"),
                new ToDoItem("Finish project"),
                new ToDoItem("Go to work!"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
