﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EntityLayer.Concrete.Activity", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("ConfirmedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ConfirmedTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndTimezone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAllDay")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaksKontenjan")
                        .HasColumnType("int");

                    b.Property<string>("RecurrenceException")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecurrenceRule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("StartTimezone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ConfirmedBy");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ActivityInvite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ActivityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ConfirmedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ConfirmedTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("InvitedUserId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("ConfirmedBy");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("InvitedUserId");

                    b.ToTable("ActivityInvite");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("EntityLayer.Concrete.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EntityLayer.Concrete.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Activity", b =>
                {
                    b.HasOne("EntityLayer.Concrete.User", "ConfirmedUser")
                        .WithMany()
                        .HasForeignKey("ConfirmedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("EntityLayer.Concrete.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.User", "DeletedUser")
                        .WithMany()
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("EntityLayer.Concrete.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ConfirmedUser");

                    b.Navigation("CreatedUser");

                    b.Navigation("DeletedUser");

                    b.Navigation("UpdatedUser");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ActivityInvite", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Activity", "AIActivity")
                        .WithMany("Invitees")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.User", "AIConfirmedUser")
                        .WithMany()
                        .HasForeignKey("ConfirmedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("EntityLayer.Concrete.User", "AICreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.User", "AIDeletedUser")
                        .WithMany()
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("EntityLayer.Concrete.User", "InvitedUser")
                        .WithMany()
                        .HasForeignKey("InvitedUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AIActivity");

                    b.Navigation("AIConfirmedUser");

                    b.Navigation("AICreatedUser");

                    b.Navigation("AIDeletedUser");

                    b.Navigation("InvitedUser");
                });

            modelBuilder.Entity("EntityLayer.Concrete.UserRole", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Activity", b =>
                {
                    b.Navigation("Invitees");
                });
#pragma warning restore 612, 618
        }
    }
}
