﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using persistence;

namespace persistence.Migrations
{
    [DbContext(typeof(ThemisContext))]
    [Migration("20190210140245_added-plans")]
    partial class addedplans
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("persistence.Chore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("PlanId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.ToTable("Chores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Ask Pinky and Brain for details!",
                            Title = "Establish World Domination"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Once you dominate all, declare world peace",
                            Title = "World Peace"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Take your fishing rod and decoys and get some fish.",
                            Title = "Go Fishing"
                        });
                });

            modelBuilder.Entity("persistence.Plan", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("UserListText");

                    b.HasKey("Id");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("persistence.Chore", b =>
                {
                    b.HasOne("persistence.Plan")
                        .WithMany("Chores")
                        .HasForeignKey("PlanId");
                });
#pragma warning restore 612, 618
        }
    }
}
