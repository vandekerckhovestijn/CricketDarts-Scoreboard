﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pin.CricketDarts.Infrastructure.Data;

#nullable disable

namespace Pin.CricketDarts.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230108215523_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CurrentTurnId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("TournamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Doubles")
                        .HasColumnType("int");

                    b.Property<bool>("HasTurn")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalPointsScored")
                        .HasColumnType("int");

                    b.Property<Guid>("TournamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Triples")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.PlayerGame", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlayerId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("PlayerGame", (string)null);
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.ScoreBoardEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountClicks")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Target")
                        .HasColumnType("int");

                    b.Property<Guid?>("TurnId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TurnId");

                    b.ToTable("ScoreBoardEntries");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Tournament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsOngoing")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Turn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrentAmountOfThrows")
                        .HasColumnType("int");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PointsScored")
                        .HasColumnType("int");

                    b.Property<bool>("SelectionMode")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Turns");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Game", b =>
                {
                    b.HasOne("Pin.CricketDarts.Core.Entities.Tournament", "Tournament")
                        .WithMany("Games")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Player", b =>
                {
                    b.HasOne("Pin.CricketDarts.Core.Entities.Tournament", "Tournament")
                        .WithMany("Participants")
                        .HasForeignKey("TournamentId");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.PlayerGame", b =>
                {
                    b.HasOne("Pin.CricketDarts.Core.Entities.Game", "Game")
                        .WithMany("PlayerGames")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pin.CricketDarts.Core.Entities.Player", "Player")
                        .WithMany("PlayerGames")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.ScoreBoardEntry", b =>
                {
                    b.HasOne("Pin.CricketDarts.Core.Entities.Game", "Game")
                        .WithMany("ScoreBoard")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pin.CricketDarts.Core.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pin.CricketDarts.Core.Entities.Turn", "Turn")
                        .WithMany("ScoreBoardEntries")
                        .HasForeignKey("TurnId");

                    b.Navigation("Game");

                    b.Navigation("Player");

                    b.Navigation("Turn");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Game", b =>
                {
                    b.Navigation("PlayerGames");

                    b.Navigation("ScoreBoard");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Player", b =>
                {
                    b.Navigation("PlayerGames");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Tournament", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("Pin.CricketDarts.Core.Entities.Turn", b =>
                {
                    b.Navigation("ScoreBoardEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
