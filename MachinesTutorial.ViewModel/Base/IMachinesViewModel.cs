using MachinesTutorial.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesTutorial.ViewModel.Base
{
    public interface IMachinesViewModel
    {
        public void LoadMachines();
     
        public void LoadStep();
    }
}
