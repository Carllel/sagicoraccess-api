using Microsoft.EntityFrameworkCore;
using Sagicor.Access.Domain.Entities;


namespace HR.LeaveManagement.Persistence.DatabaseContext
{
    public class SagicorAccessDbContext : DbContext
    {
        
        public SagicorAccessDbContext(DbContextOptions<SagicorAccessDbContext> options) : base(options)
        {
   
        }

        public DbSet<PLCategory> PLCategories { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(SagicorAccessDbContext).Assembly);
        //    base.OnModelCreating(modelBuilder);
        //}

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
        //        .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        //    {
        //        entry.Entity.DateModified = DateTime.Now;
        //        entry.Entity.ModifiedBy = _userService.UserId;
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Entity.DateCreated = DateTime.Now;
        //            entry.Entity.CreatedBy = _userService.UserId;
        //        }
        //    }

        //    return base.SaveChangesAsync(cancellationToken);
        //}

    }
}
