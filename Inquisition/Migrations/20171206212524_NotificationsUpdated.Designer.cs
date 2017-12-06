﻿// <auto-generated />
using Inquisition.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Inquisition.Migrations
{
    [DbContext(typeof(InquisitionContext))]
    [Migration("20171206212524_NotificationsUpdated")]
    partial class NotificationsUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inquisition.Data.Game", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100);

                    b.Property<string>("Exe");

                    b.Property<bool>("IsOnline");

                    b.Property<string>("LaunchArgs");

                    b.Property<string>("Port")
                        .HasMaxLength(10);

                    b.Property<string>("Version")
                        .HasMaxLength(10);

                    b.HasKey("Name");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Inquisition.Data.Joke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorName");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<int>("NegativeVotes");

                    b.Property<int>("PositiveVotes");

                    b.Property<string>("Text");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Jokes");
                });

            modelBuilder.Entity("Inquisition.Data.Meme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorName");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("Url");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Memes");
                });

            modelBuilder.Entity("Inquisition.Data.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorName");

                    b.Property<string>("TargetId");

                    b.Property<string>("TargetName");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Inquisition.Data.Reminder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorName");

                    b.Property<DateTimeOffset>("CreateDate");

                    b.Property<DateTimeOffset>("DueDate");

                    b.Property<TimeSpan>("Duration");

                    b.Property<string>("Message");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("Inquisition.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator");

                    b.Property<DateTimeOffset?>("JoinedAt");

                    b.Property<DateTimeOffset>("LastSeenOnline");

                    b.Property<string>("Nickname");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Inquisition.Data.Joke", b =>
                {
                    b.HasOne("Inquisition.Data.User", "User")
                        .WithMany("Jokes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Inquisition.Data.Meme", b =>
                {
                    b.HasOne("Inquisition.Data.User", "User")
                        .WithMany("Memes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Inquisition.Data.Notification", b =>
                {
                    b.HasOne("Inquisition.Data.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Inquisition.Data.Reminder", b =>
                {
                    b.HasOne("Inquisition.Data.User", "User")
                        .WithMany("Reminders")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
