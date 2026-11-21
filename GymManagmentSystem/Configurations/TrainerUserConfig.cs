using GymManagmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagmentSystem.Configurations
{
    public class TrainerUserConfig : GymUserConfigurations<Trainer>, IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(T => T.CreatedAt)
                .HasDefaultValueSql("GetDate()");

            base.Configure(builder);
        }
    }
}
