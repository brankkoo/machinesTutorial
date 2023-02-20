using CommunityToolkit.Mvvm.ComponentModel;
using MachinesTutorial.Services.Base;
using MachinesTutorial.ViewModel;
using MachinesTutorial.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinesTutorial.Stores
{
    public partial class NavigationStore : ObservableObject
    {
        public event Action CurrentViewModelChanged;

        private IViewModel _currentviewModel;
        public IViewModel CurrentViewModel
        {
            get { return _currentviewModel; }
            set { _currentviewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public NavigationStore(IMachineService service)
        {
            CurrentViewModel = new MachinesViewModel(service,this);
        }
      
    }
}
