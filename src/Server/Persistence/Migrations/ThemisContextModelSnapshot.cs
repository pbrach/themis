﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(ThemisContext))]
    partial class ThemisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("Persistence.DbTypes.DbChore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssignedUsers");

                    b.Property<string>("DbPlanId");

                    b.Property<string>("Description");

                    b.Property<uint>("Duration");

                    b.Property<string>("IntervalType");

                    b.Property<DateTime>("StartDay");

                    b.Property<int>("StartOfWeek");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("DbPlanId");

                    b.ToTable("Chores");
                });

            modelBuilder.Entity("Persistence.DbTypes.DbPlan", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<string>("Token");

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
