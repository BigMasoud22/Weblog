using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System.Reflection.Emit;

namespace DataBase
{
    public class Context:IdentityDbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
                
        }
        public DbSet<User> users { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Blog> blog_images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region Blog 
            builder.Entity<Blog>()
            .HasKey(t => t.Id);

            builder.Entity<Blog>()
                .Property(t => t.Title)
                .HasColumnName("Blog-Title")
                .HasMaxLength(70)
            .IsRequired();

            builder.Entity<Blog>()
                .Property(t => t.Body)
                .HasColumnName("Blog-Text")
            .IsRequired();

            builder.Entity<Blog>()
                .Property(t => t.Description)
                .HasColumnName("Blog-Description")
                .HasMaxLength(100)
                .IsRequired();
            #endregion
            #region Blog Image
            builder.Entity<BlogImage>()
                .HasKey(t => t.Id);

            builder.Entity<BlogImage>()
                .Property(t => t.imgAddress)
            .IsRequired();

            builder.Entity<BlogImage>()
            .Property(t => t.Title)
            .HasMaxLength(15)
            .HasColumnName("Image-Title")
            .IsRequired();

            builder.Entity<BlogImage>()
            .Property(t => t.alttext)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar");
            #endregion
        }
    }
}
