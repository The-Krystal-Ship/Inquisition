﻿// <auto-generated />
using System;
using TheKrystalShip.Inquisition.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TheKrystalShip.Inquisition.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("Inquisition.Database.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Arguments");

                    b.Property<DateTime>("DueTime");

                    b.Property<string>("GuildId");

                    b.Property<string>("Name");

                    b.Property<DateTime>("ScheduledTime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Inquisition.Database.Models.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TargetUserId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TargetUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("Inquisition.Database.Models.Deal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ExpireDate");

                    b.Property<string>("MessageId");

                    b.Property<string>("Url");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("Inquisition.Database.Models.Game", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100);

                    b.Property<string>("Arguments")
                        .HasMaxLength(500);

                    b.Property<string>("FileName")
                        .HasMaxLength(500);

                    b.Property<bool>("IsOnline");

                    b.Property<string>("Port")
                        .HasMaxLength(10);

                    b.Property<string>("Version")
                        .HasMaxLength(10);

                    b.HasKey("Name");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Inquisition.Database.Models.Guild", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuditChannelId");

                    b.Property<string>("IconUrl");

                    b.Property<int>("MemberCount");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Prefix");

                    b.HasKey("Id");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("Inquisition.Database.Models.Joke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Jokes");
                });

            modelBuilder.Entity("Inquisition.Database.Models.Reminder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DueDate");

                    b.Property<string>("Message");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("Inquisition.Database.Models.Server", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GuildId");

                    b.Property<string>("Nickname")
                        .HasMaxLength(50);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("UserId");

                    b.ToTable("Server");
                });

            modelBuilder.Entity("Inquisition.Database.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<string>("AvatarUrl");

                    b.Property<string>("Discriminator")
                        .HasMaxLength(10);

                    b.Property<int?>("TimezoneOffset");

                    b.Property<string>("Username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Inquisition.Database.Models.Activity", b =>
                {
                    b.HasOne("Inquisition.Database.Models.Guild", "Guild")
                        .WithMany()
                        .HasForeignKey("GuildId");

                    b.HasOne("Inquisition.Database.Models.User", "User")
                        .WithMany("Activities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inquisition.Database.Models.Alert", b =>
                {
                    b.HasOne("Inquisition.Database.Models.User", "TargetUser")
                        .WithMany("TargetAlerts")
                        .HasForeignKey("TargetUserId");

                    b.HasOne("Inquisition.Database.Models.User", "User")
                        .WithMany("Alerts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inquisition.Database.Models.Deal", b =>
                {
                    b.HasOne("Inquisition.Database.Models.User", "User")
                        .WithMany("Deals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inquisition.Database.Models.Joke", b =>
                {
                    b.HasOne("Inquisition.Database.Models.User", "User")
                        .WithMany("Jokes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inquisition.Database.Models.Reminder", b =>
                {
                    b.HasOne("Inquisition.Database.Models.User", "User")
                        .WithMany("Reminders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inquisition.Database.Models.Server", b =>
                {
                    b.HasOne("Inquisition.Database.Models.Guild", "Guild")
                        .WithMany("Servers")
                        .HasForeignKey("GuildId");

                    b.HasOne("Inquisition.Database.Models.User", "User")
                        .WithMany("Servers")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
