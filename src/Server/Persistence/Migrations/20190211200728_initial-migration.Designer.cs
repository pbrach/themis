﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(ThemisContext))]
    [Migration("20190211200728_initial-migration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("Persistence.DbTypes.DbChore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DbPlanId");

                    b.Property<string>("Description");

                    b.Property<string>("PlanId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("DbPlanId");

                    b.ToTable("Chores");
                });

            modelBuilder.Entity("Persistence.DbTypes.DbPlan", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("UserListText");

                    b.HasKey("Id");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("Persistence.DbTypes.DbChore", b =>
                {
                    b.HasOne("Persistence.DbTypes.DbPlan")
                        .WithMany("Chores")
                        .HasForeignKey("DbPlanId");
                });
#pragma warning restore 612, 618
        }
    }
}