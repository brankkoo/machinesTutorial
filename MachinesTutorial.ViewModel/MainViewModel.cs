using CommunityToolkit.Mvvm.ComponentModel;
using MachinesTutorial.Stores;
using MachinesTutorial.ViewModel.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesTutorial.ViewModel
{
    
    public partial class MainViewModel : ObservableObject
    {
        
        public NavigationStore _navigationStore;

        public IViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore vm)
        {
            _navigationStore = vm;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
        private void OnCurrentViewModelChanged() 
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
