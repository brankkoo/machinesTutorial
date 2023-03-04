using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MachinesTutorial.Model;
using MachinesTutorial.Services.Base;
using MachinesTutorial.Stores;
using MachinesTutorial.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MachinesTutorial.ViewModel
{
    public partial class MachinesViewModel : ObservableObject, IMachinesViewModel, IViewModel
    {

        [ObservableProperty]
        public ObservableCollection<Machine>? machines;

        [ObservableProperty]
        public Machine selectedMachine;

        [ObservableProperty]
        public Step selectedStep;
        [ObservableProperty]
        public string selectedPhoto;
        public IMachineService _machineService { get; set; }

        public ICommand GoToMachine { get; }

        public ICommand GoToQuiz { get; }

        public NavigationStore _navigationstore;

        public MachinesViewModel(IMachineService machineService, NavigationStore navigationStore)
        {
            _navigationstore = navigationStore;
            _machineService = machineService;
            LoadMachines();
            GoToMachine = new RelayCommand(GoToMachineView);
            GoToQuiz = new RelayCommand(GoToQuizView);
        }

        public void LoadMachines()
        {
            List<Machine> machines = _machineService.GetMachines();
            this.Machines = new ObservableCollection<Machine>(machines);
        }

        public void LoadStep()
        {
            SelectedStep = _machineService.GetStepById(SelectedMachine.Progress.Value, SelectedMachine.Id);

        }
        private void GoToMachineView()
        {
            if ( SelectedMachine != null )
            {
                _navigationstore.CurrentViewModel = new MachineViewModel(SelectedMachine, _navigationstore, _machineService);
            }

        }

        private void GoToQuizView()
        {
            if (SelectedMachine != null && SelectedMachine.QuizQuestions != null)
            {
                _navigationstore.CurrentViewModel = new QuizViewModel(_navigationstore, SelectedMachine.QuizQuestions, _machineService);
            }
        }

    }
}
