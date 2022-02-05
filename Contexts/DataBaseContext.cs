using Company.Function.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.Function.Contexts
{
    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server={yout-database-in-azure};Database={your-database};Port=5432;User Id={your-user}};Password={yout-password};Ssl Mode=VerifyFull;");

        public DbSet<UserEntity> Users { get; set; }
    }
}
