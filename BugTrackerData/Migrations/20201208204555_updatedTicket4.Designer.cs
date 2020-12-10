﻿// <auto-generated />
using System;
using BugTrackerData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BugTrackerData.Migrations
{
    [DbContext(typeof(BugTrackerContext))]
    [Migration("20201208204555_updatedTicket4")]
    partial class updatedTicket4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BugTrackerData.Data.ProjectTaskPriority", b =>
                {
                    b.Property<int>("ProjectPriorityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectPriorityName")
                        .IsRequired();

                    b.HasKey("ProjectPriorityId");

                    b.ToTable("ProjectTaskPriorities");
                });

            modelBuilder.Entity("BugTrackerData.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("State");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BugTrackerData.Models.ApplicationUserRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleId");

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUserRoles");
                });

            modelBuilder.Entity("BugTrackerData.Models.Project", b =>
                {
                    b.Property<string>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("ActualEndDate")
                        .HasColumnType("Date");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("Date");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("Date");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("ProjectOwnerId");

                    b.Property<int?>("ProjectStatusId");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("TargetEndDate")
                        .HasColumnType("Date");

                    b.HasKey("ProjectId");

                    b.HasIndex("ProjectOwnerId");

                    b.HasIndex("ProjectStatusId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BugTrackerData.Models.ProjectStatus", b =>
                {
                    b.Property<int>("ProjectStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectStatusName");

                    b.HasKey("ProjectStatusId");

                    b.ToTable("ProjectStatuses");
                });

            modelBuilder.Entity("BugTrackerData.Models.ProjectTaskStatus", b =>
                {
                    b.Property<int>("ProjectStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectStatusName")
                        .IsRequired();

                    b.HasKey("ProjectStatusId");

                    b.ToTable("ProjectTaskStatuses");
                });

            modelBuilder.Entity("BugTrackerData.Models.ProjectTaskStatusLog", b =>
                {
                    b.Property<string>("ProjectTaskStatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LogDate");

                    b.Property<int?>("StatusProjectStatusId");

                    b.Property<string>("TicketID");

                    b.Property<string>("UserId");

                    b.HasKey("ProjectTaskStatusId");

                    b.HasIndex("StatusProjectStatusId");

                    b.HasIndex("TicketID");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectTaskStatusLogs");
                });

            modelBuilder.Entity("BugTrackerData.Models.TaskComment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("Date");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("SubmittedBy");

                    b.Property<string>("TicketID");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("Date");

                    b.HasKey("CommentID");

                    b.HasIndex("TicketID");

                    b.ToTable("TaskComments");
                });

            modelBuilder.Entity("BugTrackerData.Models.Ticket", b =>
                {
                    b.Property<string>("TicketID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("Date");

                    b.Property<string>("TicketDescription")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("TicketName")
                        .IsRequired()
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("TicketOwnerId");

                    b.Property<string>("TicketProjectProjectId");

                    b.Property<int?>("TicketStatusProjectStatusId");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("Date");

                    b.HasKey("TicketID");

                    b.HasIndex("TicketOwnerId");

                    b.HasIndex("TicketProjectProjectId");

                    b.HasIndex("TicketStatusProjectStatusId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BugTrackerData.Models.Project", b =>
                {
                    b.HasOne("BugTrackerData.Models.ApplicationUser", "ProjectOwner")
                        .WithMany()
                        .HasForeignKey("ProjectOwnerId");

                    b.HasOne("BugTrackerData.Models.ProjectStatus", "ProjectStatus")
                        .WithMany()
                        .HasForeignKey("ProjectStatusId");
                });

            modelBuilder.Entity("BugTrackerData.Models.ProjectTaskStatusLog", b =>
                {
                    b.HasOne("BugTrackerData.Models.ProjectTaskStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusProjectStatusId");

                    b.HasOne("BugTrackerData.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketID");

                    b.HasOne("BugTrackerData.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BugTrackerData.Models.TaskComment", b =>
                {
                    b.HasOne("BugTrackerData.Models.Ticket")
                        .WithMany("Comments")
                        .HasForeignKey("TicketID");
                });

            modelBuilder.Entity("BugTrackerData.Models.Ticket", b =>
                {
                    b.HasOne("BugTrackerData.Models.ApplicationUser", "TicketOwner")
                        .WithMany()
                        .HasForeignKey("TicketOwnerId");

                    b.HasOne("BugTrackerData.Models.Project", "TicketProject")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketProjectProjectId");

                    b.HasOne("BugTrackerData.Models.ProjectStatus", "TicketStatus")
                        .WithMany()
                        .HasForeignKey("TicketStatusProjectStatusId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BugTrackerData.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BugTrackerData.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BugTrackerData.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BugTrackerData.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
