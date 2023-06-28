﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainComponentManagement.Models;

#nullable disable

namespace TrainComponentManagement.Migrations
{
    [DbContext(typeof(TrainComponentContext))]
    partial class TrainComponentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TrainComponentManagement.Models.ComponentHierarchy", b =>
                {
                    b.Property<int>("ParentComponentID")
                        .HasColumnType("int");

                    b.Property<int>("ChildComponentID")
                        .HasColumnType("int");

                    b.HasKey("ParentComponentID", "ChildComponentID");

                    b.HasIndex("ChildComponentID");

                    b.ToTable("ComponentHierarchies");
                });

            modelBuilder.Entity("TrainComponentManagement.Models.TrainComponent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("CanAssignQuantity")
                        .HasColumnType("bit");

                    b.Property<int?>("ItemAmount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniqueNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TrainComponents");
                });

            modelBuilder.Entity("TrainComponentManagement.Models.ComponentHierarchy", b =>
                {
                    b.HasOne("TrainComponentManagement.Models.TrainComponent", "ChildComponent")
                        .WithMany()
                        .HasForeignKey("ChildComponentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TrainComponentManagement.Models.TrainComponent", "ParentComponent")
                        .WithMany()
                        .HasForeignKey("ParentComponentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChildComponent");

                    b.Navigation("ParentComponent");
                });
#pragma warning restore 612, 618
        }
    }
}