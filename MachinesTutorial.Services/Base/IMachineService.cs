using MachinesTutorial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesTutorial.Services.Base
{
    public interface IMachineService
    {
        public List<Machine> GetMachines();
        public Step GetStepById(int id, int machineId);
        public void UpdateMachine(Machine machine);
    }
}
