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
                .HasKey(t => t.Id);
            builder
                .Property(u => u.UserName)
                .HasColumnName("username")
                .HasMaxLength(70)
                .IsRequired();
            builder
                .Property(t => t.FullName)
                .HasColumnName("fullname")
                .IsRequired();
            builder
                .Property(t => t.PhoneNumber)
                .HasColumnName("phonenumber")
                .HasMaxLength(13)
                .HasColumnType("char")
                .IsRequired();
        }
    }
}
