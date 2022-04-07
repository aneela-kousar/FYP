﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskBossApi.Models;

namespace TaskBossApi.Migrations
{
    [DbContext(typeof(TaskBossContext))]
    [Migration("20211221091854_InitilizeDB")]
    partial class InitilizeDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskBoss.Models.Domain", b =>
                {
                    b.Property<int>("DomainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DomainName")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DomainId");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("TaskBossApi.Models.AppliedProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplierId")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AppliedProjects");
                });

            modelBuilder.Entity("TaskBossApi.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DomainId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserClass")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("TaskBossApi.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("DomainId")
                        .HasColumnType("int");

                    b.Property<int>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAssigned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerType")
                        .HasColumnType("int");

                    b.Property<string>("Skill")
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("SubDomainId")
                        .HasColumnType("int");

                    b.Property<int>("TimeRequired")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TaskBossApi.Models.Skills", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.Property<string>("SkillName")
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("TaskBossApi.Models.SubDomain", b =>
                {
                    b.Property<int>("SubDomainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DomainId")
                        .HasColumnType("int");

                    b.Property<string>("SubDomainName")
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("SubDomainId");

                    b.ToTable("SubDomains");
                });

            modelBuilder.Entity("TaskBossApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DomainId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("SubDomainId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskBossApi.Models.UserSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
