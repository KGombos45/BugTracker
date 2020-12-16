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
    [Migration("20201214154007_datetodatetime2")]
    partial class datetodatetime2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BugTrackerData.Data.Project", b =>
                {
                    b.Property<string>("ProjectID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("Date");

                    b.Property<string>("Description");

                    b.Property<string>("ProjectName");

                    b.HasKey("ProjectID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("BugTrackerData.Data.WorkItemPriority", b =>
                {
                    b.Property<int>("PriorityID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PriorityName")
                        .IsRequired();

                    b.HasKey("PriorityID");

                    b.ToTable("WorkItemPriorities");
                });

            modelBuilder.Entity("BugTrackerData.Data.WorkItemType", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .IsRequired();

                    b.HasKey("TypeID");

                    b.ToTable("WorkItemTypes");
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

                    b.Property<string>("Role");

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

            modelBuilder.Entity("BugTrackerData.Models.ProjectTaskStatusLog", b =>
                {
                    b.Property<string>("ProjectTaskStatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LogDate");

                    b.Property<int?>("StatusID");

                    b.Property<string>("TicketID");

                    b.Property<string>("UserId");

                    b.HasKey("ProjectTaskStatusId");

                    b.HasIndex("StatusID");

                    b.HasIndex("TicketID");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectTaskStatusLogs");
                });

            modelBuilder.Entity("BugTrackerData.Models.Ticket", b =>
                {
                    b.Property<string>("TicketID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("Date");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("Date");

                    b.Property<string>("TicketDescription")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("TicketName")
                        .IsRequired()
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("TicketOwnerID");

                    b.Property<int>("TicketStatusID");

                    b.Property<int>("TicketTypeID");

                    b.Property<string>("TicketWorkItemID");

                    b.HasKey("TicketID");

                    b.HasIndex("TicketOwnerID");

                    b.HasIndex("TicketStatusID");

                    b.HasIndex("TicketTypeID");

                    b.HasIndex("TicketWorkItemID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("BugTrackerData.Models.TicketStatus", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .IsRequired();

                    b.HasKey("StatusID");

                    b.ToTable("TicketStatuses");
                });

            modelBuilder.Entity("BugTrackerData.Models.TicketType", b =>
                {
                    b.Property<int>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .IsRequired();

                    b.HasKey("TypeID");

                    b.ToTable("TicketTypes");
                });

            modelBuilder.Entity("BugTrackerData.Models.WorkItem", b =>
                {
                    b.Property<string>("WorkItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("ActualEndDate")
                        .HasColumnType("Date");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("Date");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("TargetEndDate")
                        .HasColumnType("Date");

                    b.Property<string>("WorkItemDescription")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("WorkItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("WorkItemOwnerID");

                    b.Property<int>("WorkItemPriorityID");

                    b.Property<string>("WorkItemProjectID");

                    b.Property<int>("WorkItemStatusID");

                    b.Property<int>("WorkItemTypeID");

                    b.HasKey("WorkItemID");

                    b.HasIndex("WorkItemOwnerID");

                    b.HasIndex("WorkItemPriorityID");

                    b.HasIndex("WorkItemProjectID");

                    b.HasIndex("WorkItemStatusID");

                    b.HasIndex("WorkItemTypeID");

                    b.ToTable("WorkItems");
                });

            modelBuilder.Entity("BugTrackerData.Models.WorkItemComment", b =>
                {
                    b.Property<string>("CommentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("CommentWorkItemID");

                    b.Property<string>("SubmittedBy");

                    b.Property<DateTime>("SubmittedOn")
                        .HasColumnType("DateTime");

                    b.HasKey("CommentID");

                    b.HasIndex("CommentWorkItemID");

                    b.ToTable("WorkItemComments");
                });

            modelBuilder.Entity("BugTrackerData.Models.WorkItemStatus", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .IsRequired();

                    b.HasKey("StatusID");

                    b.ToTable("WorkItemStatuses");
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

            modelBuilder.Entity("BugTrackerData.Models.ProjectTaskStatusLog", b =>
                {
                    b.HasOne("BugTrackerData.Models.TicketStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID");

                    b.HasOne("BugTrackerData.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketID");

                    b.HasOne("BugTrackerData.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BugTrackerData.Models.Ticket", b =>
                {
                    b.HasOne("BugTrackerData.Models.ApplicationUser", "TicketOwner")
                        .WithMany()
                        .HasForeignKey("TicketOwnerID");

                    b.HasOne("BugTrackerData.Models.TicketStatus", "TicketStatus")
                        .WithMany()
                        .HasForeignKey("TicketStatusID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BugTrackerData.Models.TicketType", "TicketType")
                        .WithMany()
                        .HasForeignKey("TicketTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BugTrackerData.Models.WorkItem", "TicketWorkItem")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketWorkItemID");
                });

            modelBuilder.Entity("BugTrackerData.Models.WorkItem", b =>
                {
                    b.HasOne("BugTrackerData.Models.ApplicationUser", "WorkItemOwner")
                        .WithMany()
                        .HasForeignKey("WorkItemOwnerID");

                    b.HasOne("BugTrackerData.Data.WorkItemPriority", "WorkItemPriority")
                        .WithMany()
                        .HasForeignKey("WorkItemPriorityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BugTrackerData.Data.Project", "Project")
                        .WithMany("WorkItems")
                        .HasForeignKey("WorkItemProjectID");

                    b.HasOne("BugTrackerData.Models.WorkItemStatus", "WorkItemStatus")
                        .WithMany()
                        .HasForeignKey("WorkItemStatusID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BugTrackerData.Data.WorkItemType", "WorkItemType")
                        .WithMany()
                        .HasForeignKey("WorkItemTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BugTrackerData.Models.WorkItemComment", b =>
                {
                    b.HasOne("BugTrackerData.Models.WorkItem", "WorkItem")
                        .WithMany("Comments")
                        .HasForeignKey("CommentWorkItemID");
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
