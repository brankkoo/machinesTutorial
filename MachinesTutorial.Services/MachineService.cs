using MachinesTutorial.Model;
using MachinesTutorial.Model.Context;
using MachinesTutorial.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesTutorial.Services
{
    public class MachineService : IMachineService
    {
        private readonly MachineContext _context;
        public MachineService(IMachineContext context)
        {
            _context= context as MachineContext;
        }

        //then include
        public List<Machine> GetMachines()
        {
            var machines = _context.Machines
                .Include(m => m.Steps)
                .ThenInclude(e => e.Photos)
                .Include(e => e.Steps)
                .ThenInclude(e => e.Video)
                .ToList();
            
            return machines;
        }

        public Step GetStepById(int id, int machineId)
        {
            var machines = GetMachines();
            if (machines != null && machines.Select(s => s.Steps) != null)
                return machines.SelectMany(s => s.Steps).FirstOrDefault(s => s.StepId == id && s.MachineId == machineId);
            else
                throw new Exception("Database is broken");
        }

        public void UpdateMachine(Machine machine)
        {
            _context.Machines.Update(machine);
            _context.SaveChanges();        
                
        }

    }
}
