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
using System.Windows;
using MachinesTutorial.Model.Dto;
using System.ComponentModel;

namespace MachinesTutorial.ViewModel
{
    public partial class QuizViewModel : ObservableObject, IViewModel
    {
        [ObservableProperty]
        public List<QuizQuestion>? quizQuestions;
        [ObservableProperty]
        public bool? isRadioButtonSeleceted;
        public NavigationStore _navigationStore;
        public IMachineService _machineService;
        public ICommand GoHome { get; set; }
        [ObservableProperty]
        public bool isQuestionWithPicture;
        [ObservableProperty]
        public bool isQuestionWithText;
        
        [ObservableProperty]
        public bool isQuestionFour;

        public QuizViewModel(NavigationStore navigationStore, List<QuizQuestion> quizQuestions, IMachineService machineService)
        {
            _navigationStore = navigationStore;
            _machineService = machineService;
            QuizQuestions = quizQuestions;
            GoHome = new RelayCommand(GoToHomeView);
          
        }

        public void GoToHomeView()
        {

            _navigationStore.CurrentViewModel = new MachinesViewModel(_machineService, _navigationStore);
        }

        public void GoToResultView()
        {

            _navigationStore.CurrentViewModel = new ResultViewModel(_navigationStore, _machineService, QuizQuestions);

        }

        public void CheckQuestionType(int id)
        {
            if (id == 1 || id == 3)
            {
                IsQuestionFour = false;
                IsQuestionWithText = false;
                IsQuestionWithPicture = true;
            }
            else if (id == 4)
            {
                IsQuestionFour = true;
                IsQuestionWithText = false;
                IsQuestionWithPicture = false;

            }
            else
            {
                IsQuestionFour = false; 
                IsQuestionWithText = true; 
                IsQuestionWithPicture = false;
            }
        }
    }
}
