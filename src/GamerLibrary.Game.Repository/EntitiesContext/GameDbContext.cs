using GamerLibrary.Common.Repository;
using Microsoft.EntityFrameworkCore;
using GameDomain = GamerLibrary.Game.Domain.Game;

namespace GamerLibrary.Game.Repository
{
    public class GameDbContext : DbContext
    {
        private readonly IDbSettings _dbSettings;

        public GameDbContext(DbContextOptions<GameDbContext> options, IDbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }

        public DbSet<GameDomain> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameDomain>().Property(entity => entity.Id).HasColumnName("Id");
            modelBuilder.Entity<GameDomain>().Property(entity => entity.CreatedDate).HasDefaultValueSql("GETDATE()");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbSettings.ConnectionString!);
        }
    }
}
