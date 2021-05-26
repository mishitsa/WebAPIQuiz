using Microsoft.EntityFrameworkCore;

namespace WebAPIApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        //public DbSet<QuestionTest> QuestionTests { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<QuestionTest>()
        //        .HasKey(qt => new { qt.QuestionId, qt.TestId });
        //}
    }
}