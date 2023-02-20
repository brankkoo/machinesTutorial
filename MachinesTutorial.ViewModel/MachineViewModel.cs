using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MachinesTutorial.Model;
using MachinesTutorial.Services.Base;
using MachinesTutorial.Stores;
using MachinesTutorial.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MachinesTutorial.ViewModel
{

    public partial class MachineViewModel : ObservableObject, IViewModel
    {
        [ObservableProperty]
        public Machine machine;
        [ObservableProperty]
        public int startIndex;

        public NavigationStore _navigationStore;
        public IMachineService _machineService;
        public ICommand GoHome { get; set; }
        public MachineViewModel(Machine machine, NavigationStore navigationStore, IMachineService machineService)
        {
            this.machine = machine;
            startIndex = machine.Progress.Value - 1;
            _navigationStore = navigationStore;
            _machineService = machineService;
            GoHome = new RelayCommand(GoToHomeView);
        }

        private void GoToHomeView()
        {
            _machineService.UpdateMachine(this.Machine);
            _navigationStore.CurrentViewModel = new MachinesViewModel(_machineService, _navigationStore);
        }
    }
}
