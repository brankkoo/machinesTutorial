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
                    Title = "Connect the air compressor to machine air input:",
                },
                new Step
                {
                    MachineId = 1,
                    StepId = 2,
                    Title = "Start power:"
                },
                new Step
                {
                    MachineId = 1,
                    StepId = 3,
                    Title = "Set parameters of temperature:",
                    Description = "For more details, please check the following ID \r\nIntelligent Temperature Controller instructions"
                },
                new Step
                {
                    MachineId = 1,
                    StepId = 4,
                    Title = "Driving system:",
                    Description = "Press down for making rods down, \r\nthen material will come out.Rods for pressing material.Press upward for making rods rising.Rods for pressing material"
                },
                new Step
                {
                    MachineId = 1,
                    StepId = 5,
                    Title = " Adjusting mold",
                    Description = "The height between base and injector mouth is 8cm. If you want adjust height, please adjust it \r\naccording to the instructions. Unscrew and remove fastening \r\nscrews and adjusting the height"
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

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite($"Data Source={DbPath}");
    }
}
