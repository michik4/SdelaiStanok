﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SdelaiStanokAPI.data;

#nullable disable

namespace SdelaiStanokAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241026122654_RefreshDatabase2")]
    partial class RefreshDatabase2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GalleryItemTag", b =>
                {
                    b.Property<int>("GalleryItemsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("GalleryItemsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("GalleryItemTags", (string)null);
                });

            modelBuilder.Entity("SdelaiStanokAPI.models.Description", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("SdelaiStanokAPI.models.GalleryImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GalleryItemId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GalleryItemId");

                    b.ToTable("GalleryImages");
                });

            modelBuilder.Entity("SdelaiStanokAPI.models.GalleryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DescriptionId")
                        .HasColumnType("int");

                    b.Property<string>("MainImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId")
                        .IsUnique();

                    b.ToTable("GalleryItems");
                });

            modelBuilder.Entity("SdelaiStanokAPI.models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("GalleryItemTag", b =>
                {
                    b.HasOne("SdelaiStanokAPI.models.GalleryItem", null)
                        .WithMany()
                        .HasForeignKey("GalleryItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SdelaiStanokAPI.models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SdelaiStanokAPI.models.GalleryImage", b =>
                {
                    b.HasOne("SdelaiStanokAPI.models.GalleryItem", "GalleryItem")
                        .WithMany("Images")
                        .HasForeignKey("GalleryItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GalleryItem");
                });

            modelBuilder.Entity("SdelaiStanokAPI.models.GalleryItem", b =>
                {
                    b.HasOne("SdelaiStanokAPI.models.Description", "Description")
                        .WithOne()
                        .HasForeignKey("SdelaiStanokAPI.models.GalleryItem", "DescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Description");
                });

            modelBuilder.Entity("SdelaiStanokAPI.models.GalleryItem", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
