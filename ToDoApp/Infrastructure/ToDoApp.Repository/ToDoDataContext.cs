using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using ToDoApp.Entity.Entities;
using ToDoApp.Identity.User;

namespace ToDoApp.Repository
{
    public class ToDoDataContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ToDoDataContext(DbContextOptions<ToDoDataContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
