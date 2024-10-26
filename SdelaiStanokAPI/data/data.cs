/*
using Microsoft.EntityFrameworkCore;
using SdelaiStanokAPI.models;

namespace GalleryApi.data { 
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<GalleryItem> GalleryItems { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Description> Descriptions { get; set; }

        // (Опционально) Fluent API для дополнительных настроек, например:
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<GalleryItem>()
        //         .HasMany(g => g.Images)
        //         .WithOne(i => i.GalleryItem)
        //         .HasForeignKey(i => i.GalleryItemId);

        //    // ... другие настройки
        // }
    }
}
*/
using Microsoft.EntityFrameworkCore;
using SdelaiStanokAPI.models;

namespace SdelaiStanokAPI.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<GalleryItem> GalleryItems { get; set; } = null!;
        public DbSet<GalleryImage> GalleryImages { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<Description> Descriptions { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GalleryItem>()
                .HasOne(g => g.Description)
                .WithOne()
                .HasForeignKey<GalleryItem>(g => g.DescriptionId);

            modelBuilder.Entity<GalleryItem>()
                .HasMany(g => g.Tags)
                .WithMany(t => t.GalleryItems)
                .UsingEntity(j => j.ToTable("GalleryItemTags"));

            modelBuilder.Entity<GalleryImage>()
                .HasOne(i => i.GalleryItem)
                .WithMany(g => g.Images)
                .HasForeignKey(i => i.GalleryItemId);

            base.OnModelCreating(modelBuilder);
        }
    }
}