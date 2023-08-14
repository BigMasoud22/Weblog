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
                .HasColumnName("Image-Title")
                .IsRequired();
            builder
                .Property(t => t.alttext)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");
        }
    }
}
