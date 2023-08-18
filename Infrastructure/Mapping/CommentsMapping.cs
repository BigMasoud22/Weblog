using Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class CommentsMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.text)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(300);
            builder.HasOne(u => u.user)
                .WithMany(c => c.comments)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
