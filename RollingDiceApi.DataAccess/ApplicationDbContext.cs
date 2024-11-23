namespace RollingDiceApi.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using RollingDiceApi.DataAccess.Models;

    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<RolledDiceData> RolledDice { get; set; }
    }
}
