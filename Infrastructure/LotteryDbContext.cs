using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RoosterLottery.Domain.Entities;
using System;

namespace RoosterLottery.Infrastructure
{
    public class LotteryDbContext : DbContext
    {
        public LotteryDbContext(DbContextOptions<LotteryDbContext> options) : base(options)
        { 
        }

        DbSet<LotteryUser> LotteryUsers { get; set; }
        DbSet<Bet> Bets { get; set; }
        DbSet<DialOpenLottery> DialOpenLotteries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.ClrType.IsAssignableTo(typeof(BaseEntity)))
                {
                    entity?.FindProperty(nameof(BaseEntity.CreatedDate))?.SetDefaultValueSql("'NOW()'");
                    entity?.FindProperty(nameof(BaseEntity.CreatedBy))?.SetDefaultValue("Admin");
                    entity?.FindProperty(nameof(BaseEntity.UpdatedDate))?.SetDefaultValueSql("'NOW()'");
                    entity?.FindProperty(nameof(BaseEntity.UpdatedBy))?.SetDefaultValue("Admin");
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>().ToList();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "Admin";
                    entry.Entity.UpdatedDate = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = "Admin";
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = "Admin";
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}
