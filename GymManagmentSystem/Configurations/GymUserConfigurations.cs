using GymManagmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagmentSystem.Configurations
{
    public class GymUserConfigurations<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(U => U.Name)
                 .HasColumnType("varchar")
                 .HasMaxLength(50);

            builder.Property(U => U.Phone)
                 .HasColumnType("varchar")
                 .HasMaxLength(11);

            builder.HasIndex(U => U.Phone).IsUnique();

            builder.HasIndex(U => U.Email).IsUnique();

            builder.ComplexProperty(U => U.Address);

            builder.ToTable(Tb =>
            {
                Tb.HasCheckConstraint("CK_Email", "Email Like '_%@_%._%'");
                Tb.HasCheckConstraint("CK_Phone", "Len(Phone) = 11 And (Phone like '010%' or Phone like '011%' or Phone like '012%' or Phone like '015%')");
            });
        }
    }
}
