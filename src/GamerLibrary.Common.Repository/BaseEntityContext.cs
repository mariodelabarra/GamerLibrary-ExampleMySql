using GamerLibrary.Common.Domain;
using Microsoft.EntityFrameworkCore;

namespace GamerLibrary.Common.Repository
{
    public class BaseEntityContext<IBaseEntity> : DbContext
        where IBaseEntity : BaseEntity
    {
        private readonly IDbSettings _dbSettings;

        public BaseEntityContext(
            DbContextOptions<BaseEntityContext<IBaseEntity>> options,
            IDbSettings dbSettings)
            : base(options)
        {
            _dbSettings = dbSettings;
        }
        public DbSet<IBaseEntity> CurrentEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IBaseEntity>().Property(entity => entity.Id).HasColumnName("Id");
            modelBuilder.Entity<IBaseEntity>().Property(entity => entity.CreatedDate).HasDefaultValueSql("GETDATE()");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbSettings.ConnectionString!);
        }
    }
}
