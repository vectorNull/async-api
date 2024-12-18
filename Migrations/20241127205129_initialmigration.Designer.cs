﻿// <auto-generated />
using AsyncApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241127205129_initialmigration")]
    partial class Initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("AsyncApi.Models.ListingRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("EstimatedCompletionTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestBody")
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestStatus")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ListingRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
