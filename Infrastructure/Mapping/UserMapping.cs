using Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(t => t.id);
            builder
                .Property(u => u.Email)
                .HasMaxLength(70)
                .IsRequired();
            builder
                .Property(t => t.FullName)
                .IsRequired();
            builder.HasMany(c => c.comments)
                .WithOne(u => u.user)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
