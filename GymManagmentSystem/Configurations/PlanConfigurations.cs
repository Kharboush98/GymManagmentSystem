using GymManagmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagmentSystem.Configurations
{
    public class PlanConfigurations : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GetDate()");

            builder.ToTable(TB =>
            {
                TB.HasCheckConstraint("CK_DurationDays", "DurationDays Between 1 And 365");
            });
        }
    }
}
