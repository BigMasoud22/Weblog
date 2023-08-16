using Domain.BlogAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class BlogImageMapping : IEntityTypeConfiguration<BlogImage>
    {
        public void Configure(EntityTypeBuilder<BlogImage> builder)
        {
            builder
                .HasKey(t => t.Id);
            builder
                .Property(t => t.imgAddress)
                .IsRequired();
            builder
                .Property(t => t.Title)
                .HasMaxLength(15)
                .IsRequired();
            builder
                .Property(t => t.alttext)
                .IsRequired()
                .HasMaxLength(50);
            builder.
                HasOne(t => t.blog)
                .WithOne(t => t.image);
        }
    }
}
