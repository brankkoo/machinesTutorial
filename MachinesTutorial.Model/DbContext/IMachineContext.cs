using Microsoft.EntityFrameworkCore;

namespace MachinesTutorial.Model.Context
{
    public interface IMachineContext
    {
        public DbSet<Machine> Machines { get; set; }

        public DbSet<Step> Steps { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Photo> Photos { get; set; }
        public string DbPath { get;   }
    }
}