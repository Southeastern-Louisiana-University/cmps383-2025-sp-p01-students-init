﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Selu383.SP25.Api.Data;

#nullable disable

namespace Selu383.SP25.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Selu383.SP25.Api.Entities.Theater", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("SeatCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Theaters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 W University Ave",
                            Name = "Lions Den Grande Theater",
                            SeatCount = 200
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Palace Dr",
                            Name = "Lions Den Mega Theater",
                            SeatCount = 150
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 S Range Rd",
                            Name = "Lions Den Green and Gold Theater",
                            SeatCount = 100
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
