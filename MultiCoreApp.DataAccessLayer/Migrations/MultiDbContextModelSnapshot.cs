﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiCoreApp.DataAccessLayer;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    [DbContext(typeof(MultiDbContext))]
    partial class MultiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MultiCoreApp.Core.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tblCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("113b6e77-bdb7-4b0d-8b15-ae7387ff65f5"),
                            IsDeleted = false,
                            Name = "Pencils"
                        },
                        new
                        {
                            Id = new Guid("b3e18e1f-01fa-46b8-a2ea-d51772910dbf"),
                            IsDeleted = false,
                            Name = "Books"
                        });
                });

            modelBuilder.Entity("MultiCoreApp.Core.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("tblProducts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8c9f19b5-11ea-4737-a098-85e77bf98624"),
                            CategoryId = new Guid("113b6e77-bdb7-4b0d-8b15-ae7387ff65f5"),
                            IsDeleted = false,
                            Name = "Dolma Pencil",
                            Price = 12.53m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("666b9199-3d90-469d-8dbb-dbe2ad9a06cc"),
                            CategoryId = new Guid("113b6e77-bdb7-4b0d-8b15-ae7387ff65f5"),
                            IsDeleted = false,
                            Name = "Tükenmez Pencil",
                            Price = 122.53m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("056230f2-74bd-41ba-8927-ec9b267a624e"),
                            CategoryId = new Guid("113b6e77-bdb7-4b0d-8b15-ae7387ff65f5"),
                            IsDeleted = false,
                            Name = "Kurşun Pencil",
                            Price = 62.53m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("0afa79d4-fbb2-4e60-962a-e9602f4fce3f"),
                            CategoryId = new Guid("b3e18e1f-01fa-46b8-a2ea-d51772910dbf"),
                            IsDeleted = false,
                            Name = "Çizgili Book",
                            Price = 23.53m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("d4a925d1-8bcf-48d5-ac1f-bb0efd45c7b9"),
                            CategoryId = new Guid("b3e18e1f-01fa-46b8-a2ea-d51772910dbf"),
                            IsDeleted = false,
                            Name = "Kareli Book",
                            Price = 11.53m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("c40c987b-0942-4cdc-9b46-9d98ca85394a"),
                            CategoryId = new Guid("b3e18e1f-01fa-46b8-a2ea-d51772910dbf"),
                            IsDeleted = false,
                            Name = "Dümdüz Book",
                            Price = 44.53m,
                            Stock = 100
                        });
                });

            modelBuilder.Entity("MultiCoreApp.Core.Models.Product", b =>
                {
                    b.HasOne("MultiCoreApp.Core.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MultiCoreApp.Core.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
