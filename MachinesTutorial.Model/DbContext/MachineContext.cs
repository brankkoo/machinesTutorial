using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesTutorial.Model.Context
{
    public class MachineContext : DbContext, IMachineContext
    {
        public DbSet<Machine> Machines { get; set; }

        public DbSet<Step> Steps { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<QuizQuestion> QuizQuestions { get; set; }

        public DbSet<QuizChoice> QuizChoices { get; set; }
        public string DbPath { get; }

        public MachineContext()
        {
            
            var path = "";
            DbPath = System.IO.Path.Join(path, "./Machinedb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Machine>(machine =>
            {
                machine.HasMany(m => m.Steps).WithOne(m => m.Machine);
                machine.HasMany(m => m.QuizQuestions).WithOne(m => m.Machine);
                machine.HasData(new Machine
                {
                    Id = 1,
                    Name = "wz30000 AIR COMRESSOR",
                    Progress = 0,
                    PhotoSource = "/Images/w30k/main.jpg"

                }) ;
                
            });

            modelBuilder.Entity<Step>(step =>
            {
                step.HasMany(s => s.Photos).WithOne(m => m.Step);
                step.HasMany(s => s.Video).WithOne(s => s.Step);

                step.HasData(new Step
                {
                    MachineId = 1,
                    StepId = 1,
                    Title = "Step 1",
                    Description = "Fix the mould to the under vice, tight it well and proceed with the operation of the\r\nmachine",
                    OrderNum= 1,
                },
                new Step
                {
                    MachineId = 1,
                    StepId = 2,
                    Title = "Step 2",
                    Description = "Air connection: Verify the air compressor is on and the air pressure hose is\r\nconnected to the machine",
                    OrderNum = 2,
                },
                new Step
                {
                    MachineId = 1,
                    StepId = 3,
                    Title = "Step 3",
                    Description = "Start",
                    OrderNum = 3,
                },
                new Step
                {
                    MachineId = 1,
                    StepId = 4,
                    Title = "Step 4",
                    Description = "Set temperature parameter"
                ,
                    OrderNum = 4
                },
                new Step
                {
                    MachineId = 1,
                    StepId = 5,
                    Title = "Step 5",
                    Description = "Pull the lever down in order for the rod to go down and press the heated plastic."
                ,
                    OrderNum = 5
                },
                new Step
                {
                    MachineId = 1,
                    StepId = 6,
                    Title = "Step 6",
                    Description = "After the rod has pressed the molten material you must push the lever up for the rod\r\nto go upwards",
                    OrderNum= 6
                },
                new Step
                {
                    MachineId = 1,
                    StepId = 7,
                    Title = "Step 7",
                    Description = "Open the mould and get the final product.\r\nIf the height of the mould is not correct, on the back of the machine you will see 2 screws\r\nwhich you can use to move the machine up and down."
                ,
                    OrderNum = 7
                }
                ) ;
            
            });

            modelBuilder.Entity<Photo>(photo =>
            {
                photo.HasData(new Photo
                {
                    StepId = 1,
                    PhotoId = 1,
                    Source = "Images/w30k/Step1.png"
                },
                new Photo
                {
                    StepId = 2,
                    PhotoId = 2,
                    Source = "Images/w30k/Step2.png"
                },
                new Photo
                {
                    StepId = 3,
                    PhotoId = 3,
                    Source = "Images/w30k/Step3.png"
                },
                new Photo
                {
                    StepId = 4,
                    PhotoId = 4,
                    Source = "Images/w30k/Step4.png"
                },
                new Photo
                {
                    StepId = 5,
                    PhotoId = 5,
                    Source = "Images/w30k/Step5.png"
                }
                ) ;
            });
            modelBuilder.Entity<QuizQuestion>(quizQuestion => 
            {

                quizQuestion.HasMany(q => q.QuizChoices).WithOne(q => q.QuizQuestion);
                });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite($"Data Source={DbPath}");
    }
}
