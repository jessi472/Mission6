using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Mission6.Models;

namespace Mission6
{
    public class NewTaskContext : DbContext
    {
        public NewTaskContext(DbContextOptions<NewTaskContext> options) : base (options)
            {
            }

        public DbSet<CoveyForm> TaskResp { get; set; }

        public DbSet<Category> CategoryResp { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryTitle = "Home"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryTitle = "School"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryTitle = "Work"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryTitle = "Church"
                });

            mb.Entity<CoveyForm>().HasData(
                new CoveyForm
                { 
                    TaskId = 1,
                    Task = "Win Win Win",
                    DueDate="09-09-2022",
                    Quadrant = "1",
                    Completed = true,
                    CategoryId = 1
                });
        }
    }
}