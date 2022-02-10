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
                    DueDate = "09-09-2022",
                    Quadrant = "Important & Urgent",
                    Completed = true,
                    CategoryId = 1
                },
                new CoveyForm
                {
                    TaskId = 2,
                    Task = "Win Win Lose",
                    DueDate = "09-10-2022",
                    Quadrant = "Important & Not Urgent",
                    Completed = true,
                    CategoryId = 2
                },
                new CoveyForm
                {
                    TaskId = 3,
                    Task = "Win Lose Lose",
                    DueDate = "09-11-2022",
                    Quadrant = "Not Important & Urgent",
                    Completed = false,
                    CategoryId = 3
                },
                new CoveyForm
                {
                    TaskId = 4,
                    Task = "Lose Lose Lose",
                    DueDate = "09-12-2022",
                    Quadrant = "Not Important & Not Urgent",
                    Completed = false,
                    CategoryId = 4
                });
        }
    }
}