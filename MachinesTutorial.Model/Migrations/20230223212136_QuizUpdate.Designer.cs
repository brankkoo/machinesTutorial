﻿// <auto-generated />
using System;
using MachinesTutorial.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MachinesTutorial.Model.Migrations
{
    [DbContext(typeof(MachineContext))]
    [Migration("20230223212136_QuizUpdate")]
    partial class QuizUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("MachinesTutorial.Model.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhotoSource")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Progress")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StepId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Machines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "wz30000 AIR COMRESSOR",
                            PhotoSource = "/Images/w30k/main.jpg",
                            Progress = 0,
                            StepId = 0
                        });
                });

            modelBuilder.Entity("MachinesTutorial.Model.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Source")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StepId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PhotoId");

                    b.HasIndex("StepId");

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            PhotoId = 1,
                            Source = "Images/w30k/Step1.png",
                            StepId = 1
                        },
                        new
                        {
                            PhotoId = 2,
                            Source = "Images/w30k/Step2.png",
                            StepId = 2
                        },
                        new
                        {
                            PhotoId = 3,
                            Source = "Images/w30k/Step3.png",
                            StepId = 3
                        },
                        new
                        {
                            PhotoId = 4,
                            Source = "Images/w30k/Step4.png",
                            StepId = 4
                        },
                        new
                        {
                            PhotoId = 5,
                            Source = "Images/w30k/Step5.png",
                            StepId = 5
                        });
                });

            modelBuilder.Entity("MachinesTutorial.Model.QuizQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .HasColumnType("TEXT");

                    b.Property<int>("MachineId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Question")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.ToTable("QuizQuestion");
                });

            modelBuilder.Entity("MachinesTutorial.Model.Step", b =>
                {
                    b.Property<int>("StepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("MachineId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderNum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("StepId");

                    b.HasIndex("MachineId");

                    b.ToTable("Steps");

                    b.HasData(
                        new
                        {
                            StepId = 1,
                            Description = "Fix the mould to the under vice, tight it well and proceed with the operation of the\r\nmachine",
                            MachineId = 1,
                            OrderNum = 1,
                            Title = "Step 1"
                        },
                        new
                        {
                            StepId = 2,
                            Description = "Air connection: Verify the air compressor is on and the air pressure hose is\r\nconnected to the machine",
                            MachineId = 1,
                            OrderNum = 2,
                            Title = "Step 2"
                        },
                        new
                        {
                            StepId = 3,
                            Description = "Start",
                            MachineId = 1,
                            OrderNum = 3,
                            Title = "Step 3"
                        },
                        new
                        {
                            StepId = 4,
                            Description = "Set temperature parameter",
                            MachineId = 1,
                            OrderNum = 4,
                            Title = "Step 4"
                        },
                        new
                        {
                            StepId = 5,
                            Description = "Pull the lever down in order for the rod to go down and press the heated plastic.",
                            MachineId = 1,
                            OrderNum = 5,
                            Title = "Step 5"
                        },
                        new
                        {
                            StepId = 6,
                            Description = "After the rod has pressed the molten material you must push the lever up for the rod\r\nto go upwards",
                            MachineId = 1,
                            OrderNum = 6,
                            Title = "Step 6"
                        },
                        new
                        {
                            StepId = 7,
                            Description = "Open the mould and get the final product.\r\nIf the height of the mould is not correct, on the back of the machine you will see 2 screws\r\nwhich you can use to move the machine up and down.",
                            MachineId = 1,
                            OrderNum = 7,
                            Title = "Step 7"
                        });
                });

            modelBuilder.Entity("MachinesTutorial.Model.Video", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Source")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StepId")
                        .HasColumnType("INTEGER");

                    b.HasKey("VideoId");

                    b.HasIndex("StepId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("MachinesTutorial.Model.Photo", b =>
                {
                    b.HasOne("MachinesTutorial.Model.Step", "Step")
                        .WithMany("Photos")
                        .HasForeignKey("StepId");

                    b.Navigation("Step");
                });

            modelBuilder.Entity("MachinesTutorial.Model.QuizQuestion", b =>
                {
                    b.HasOne("MachinesTutorial.Model.Machine", "Machine")
                        .WithMany("QuizQuestions")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("MachinesTutorial.Model.Step", b =>
                {
                    b.HasOne("MachinesTutorial.Model.Machine", "Machine")
                        .WithMany("Steps")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("MachinesTutorial.Model.Video", b =>
                {
                    b.HasOne("MachinesTutorial.Model.Step", "Step")
                        .WithMany("Video")
                        .HasForeignKey("StepId");

                    b.Navigation("Step");
                });

            modelBuilder.Entity("MachinesTutorial.Model.Machine", b =>
                {
                    b.Navigation("QuizQuestions");

                    b.Navigation("Steps");
                });

            modelBuilder.Entity("MachinesTutorial.Model.Step", b =>
                {
                    b.Navigation("Photos");

                    b.Navigation("Video");
                });
#pragma warning restore 612, 618
        }
    }
}
