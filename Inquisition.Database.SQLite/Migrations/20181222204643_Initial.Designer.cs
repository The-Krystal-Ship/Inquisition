﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheKrystalShip.Inquisition.Database.SQLite;

namespace TheKrystalShip.Inquisition.Database.SQLite.Migrations
{
    [DbContext(typeof(SQLiteContext))]
    [Migration("20181222204643_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Arguments");

                    b.Property<DateTime>("DueTime");

                    b.Property<string>("GuildId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)));

                    b.Property<string>("Name");

                    b.Property<DateTime>("ScheduledTime");

                    b.Property<string>("UserId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)));

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TargetUserId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)));

                    b.Property<string>("UserId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)));

                    b.HasKey("Id");

                    b.HasIndex("TargetUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Deal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ExpireDate");

                    b.Property<ulong>("MessageId");

                    b.Property<string>("Url");

                    b.Property<string>("UserId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)));

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Game", b =>
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

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Guild", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)));

                    b.Property<string>("AuditChannelId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)));

                    b.Property<string>("IconUrl");

                    b.Property<int>("MemberCount");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Prefix");

                    b.HasKey("Id");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Joke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text");

                    b.Property<string>("UserId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)));

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Jokes");
                });

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Reminder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DueDate");

                    b.Property<string>("Message");

                    b.Property<string>("UserId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)));

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Server", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GuildId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)));

                    b.Property<string>("Nickname")
                        .HasMaxLength(50);

                    b.Property<string>("UserId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)));

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("UserId");

                    b.ToTable("Server");
                });

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)));

                    b.Property<string>("AvatarUrl");

                    b.Property<string>("Discriminator")
                        .HasMaxLength(10);

                    b.Property<int?>("TimezoneOffset");

                    b.Property<string>("Username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Activity", b =>
                {
                    b.HasOne("TheKrystalShip.Inquisition.Domain.Guild", "Guild")
                        .WithMany()
                        .HasForeignKey("GuildId");

                    b.HasOne("TheKrystalShip.Inquisition.Domain.User", "User")
                        .WithMany("Activities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Alert", b =>
                {
                    b.HasOne("TheKrystalShip.Inquisition.Domain.User", "TargetUser")
                        .WithMany("TargetAlerts")
                        .HasForeignKey("TargetUserId");

                    b.HasOne("TheKrystalShip.Inquisition.Domain.User", "User")
                        .WithMany("Alerts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Deal", b =>
                {
                    b.HasOne("TheKrystalShip.Inquisition.Domain.User", "User")
                        .WithMany("Deals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Joke", b =>
                {
                    b.HasOne("TheKrystalShip.Inquisition.Domain.User", "User")
                        .WithMany("Jokes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Reminder", b =>
                {
                    b.HasOne("TheKrystalShip.Inquisition.Domain.User", "User")
                        .WithMany("Reminders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TheKrystalShip.Inquisition.Domain.Server", b =>
                {
                    b.HasOne("TheKrystalShip.Inquisition.Domain.Guild", "Guild")
                        .WithMany("Servers")
                        .HasForeignKey("GuildId");

                    b.HasOne("TheKrystalShip.Inquisition.Domain.User", "User")
                        .WithMany("Servers")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
