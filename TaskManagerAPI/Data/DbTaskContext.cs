using Microsoft.EntityFrameworkCore;

namespace TaskManagerAPI.Data
{
    public class DbTaskContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<User> Users {get; set;}

        public DbTaskContext(DbContextOptions<DbTaskContext> options) : base(options) { }
    }
}
