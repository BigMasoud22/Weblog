using Domain.BlogAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class BlogMapping : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder
            .HasKey(t => t.Id);
            builder
                .Property(t => t.Title)
                .HasMaxLength(70)
                .IsRequired();
            builder
                .Property(t => t.Body)
                .IsRequired();
            builder
                .Property(t => t.Description)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
