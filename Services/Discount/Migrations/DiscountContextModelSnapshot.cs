﻿// <auto-generated />
using Discount.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Discount.Migrations
{
    [DbContext(typeof(DiscountContext))]
    partial class DiscountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Discount.Models.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 2000,
                            Description = "Iphone Description x",
                            ProductName = "Iphone X"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 900,
                            Description = "Iphone Description x",
                            ProductName = "Iphone 2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
