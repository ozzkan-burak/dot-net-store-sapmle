﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories;

#nullable disable

namespace StoreApp.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Book"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Electronic"
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 2,
                            Price = 17000m,
                            ProductName = "Computer"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            Price = 1000m,
                            ProductName = "Keyboard"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            Price = 500m,
                            ProductName = "Mouse"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2,
                            Price = 7000m,
                            ProductName = "Monitor"
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 2,
                            Price = 1500m,
                            ProductName = "Deck"
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 1,
                            Price = 1000m,
                            ProductName = "History OF Human"
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 1,
                            Price = 2000m,
                            ProductName = "Tüfek Mikrop ve Çelik"
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.HasOne("Entities.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
