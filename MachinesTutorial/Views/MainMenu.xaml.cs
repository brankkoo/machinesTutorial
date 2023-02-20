using MachinesTutorial.Model;
using MachinesTutorial.Model.Context;
using MachinesTutorial.ViewModel;
using MachinesTutorial.ViewModel.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MachinesTutorial.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
           
        }

        private void ListViewMach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListViewMach.SelectedItem != null) 
            {
                var selectedItem = ListViewMach.SelectedItem;
                var vm = DataContext as MachinesViewModel;
                if (vm.GetType() == typeof(MachinesViewModel))
                {

                    vm.SelectedMachine = selectedItem as Machine;
                    vm.LoadStep();
                }
            }
           
            
        }

      
    }
}
