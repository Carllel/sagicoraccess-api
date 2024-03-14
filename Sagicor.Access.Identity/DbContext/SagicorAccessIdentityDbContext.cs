using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sagicor.Access.Identity.Models;

namespace Sagicor.Access.Identity.DbContext
{
    public class SagicorAccessIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public SagicorAccessIdentityDbContext(DbContextOptions<SagicorAccessIdentityDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(SagicorAccessIdentityDbContext).Assembly);
        }
    }
}
