using GymManagmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagmentSystem.Configurations
{
    public class MembershipConfigurations : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.Property(M => M.CreatedAt)
                .HasDefaultValueSql("GetDate()");

            builder.Property(M => M.EndDate)
                .HasDefaultValueSql("GetDate()");

            builder.HasOne(M => M.Plan)
                .WithMany(p => p.Memberships)
                .HasForeignKey(M => M.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
