﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainComponentManagement.Models;

#nullable disable

namespace TrainComponentManagement.Migrations
{
    [DbContext(typeof(TrainComponentContext))]
    [Migration("20230711125449_Initialization")]
    partial class Initialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Depth")
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniqueNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TrainComponents");
                });

            modelBuilder.Entity("TrainComponentManagement.Models.TrainComponentQuantityAssignment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TrainComponentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TrainComponentID");

                    b.ToTable("TrainComponentQuantityAssignments");
                });

            modelBuilder.Entity("TrainComponentManagement.Models.ComponentHierarchy", b =>
                {
                    b.HasOne("TrainComponentManagement.Models.TrainComponent", "ChildComponent")
                        .WithMany()
                        .HasForeignKey("ChildComponentID")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("TrainComponentManagement.Models.TrainComponent", "ParentComponent")
                        .WithMany()
                        .HasForeignKey("ParentComponentID")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("ChildComponent");

                    b.Navigation("ParentComponent");
                });

            modelBuilder.Entity("TrainComponentManagement.Models.TrainComponentQuantityAssignment", b =>
                {
                    b.HasOne("TrainComponentManagement.Models.TrainComponent", "TrainComponent")
                        .WithMany()
                        .HasForeignKey("TrainComponentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainComponent");
                });
#pragma warning restore 612, 618
        }
    }
}
