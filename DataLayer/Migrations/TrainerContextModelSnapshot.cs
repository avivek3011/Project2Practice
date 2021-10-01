﻿// <auto-generated />
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(TrainerContext))]
    partial class TrainerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Skills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Trainer_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Trainer_Id");

                    b.ToTable("tb_skills");
                });

            modelBuilder.Entity("DataLayer.Entities.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_trainer");
                });

            modelBuilder.Entity("DataLayer.Entities.TrainerDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Qualification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Trainer_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Trainer_Id");

                    b.ToTable("tb_trainerdetails");
                });

            modelBuilder.Entity("DataLayer.Entities.Skill", b =>
                {
                    b.HasOne("DataLayer.Entities.Trainer", "Trainer")
                        .WithMany("Skill")
                        .HasForeignKey("Trainer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("DataLayer.Entities.TrainerDetails", b =>
                {
                    b.HasOne("DataLayer.Entities.Trainer", "Trainer")
                        .WithMany()
                        .HasForeignKey("Trainer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("DataLayer.Entities.Trainer", b =>
                {
                    b.Navigation("Skill");
                });
#pragma warning restore 612, 618
        }
    }
}
