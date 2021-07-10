using System.Data;
using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Task>(task =>
            {
                task.HasKey(t => t.Id);
                task.Property(t => t.Id).ValueGeneratedOnAdd();
                task.Property(t => t.Title).HasMaxLength(25).IsRequired();
                task.Property(t => t.Description).HasMaxLength(255).IsRequired();
            });

            base.OnModelCreating(model);
        }
    }
}
