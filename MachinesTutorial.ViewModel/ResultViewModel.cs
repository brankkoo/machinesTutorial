using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MachinesTutorial.Model;
using MachinesTutorial.Model.Dto;
using MachinesTutorial.Services;
using MachinesTutorial.Services.Base;
using MachinesTutorial.Stores;
using MachinesTutorial.ViewModel.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Windows.Input;

namespace MachinesTutorial.ViewModel
{
    public partial class ResultViewModel : ObservableObject, IViewModel
    {
        private NavigationStore _navigationStore;
        private IMachineService _machineService;
        private List<QuizQuestion> _quizQuestions;
        [ObservableProperty]
        ResultDto resultDtos;
        public ICommand GoHome { get; set; }
        public ResultViewModel(NavigationStore navigationStore, IMachineService machineService, List<QuizQuestion> quizQuestions)
        {
            _navigationStore = navigationStore;
            _machineService = machineService;
            _quizQuestions = quizQuestions;
            ResultDtos = _machineService.QuizResultCalcualtion(_quizQuestions);
            GoHome = new RelayCommand(GoToHomeView);
        }

        public void GoToHomeView()
        {

            _navigationStore.CurrentViewModel = new MachinesViewModel(_machineService, _navigationStore);
        }
    }
}