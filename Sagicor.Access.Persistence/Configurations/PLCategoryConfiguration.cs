using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sagicor.Access.Domain.Entities;

namespace Sagicor.Access.Persistence.Configurations
{
    public class PLCategoryConfiguration : IEntityTypeConfiguration<PLCategory>
    {
        public void Configure(EntityTypeBuilder<PLCategory> builder)
        {
            //builder.HasData(
            //    new LeaveType
            //    {
            //        Id = 1,
            //        Name = "Vacation",
            //        DefaultDays = 10,
            //        DateCreated = DateTime.Now,
            //        DateModified = DateTime.Now
            //    }
            //);

            //builder.Property(q => q.Name)
            //    .IsRequired()
            //    .HasMaxLength(100);
        }
    }
}
