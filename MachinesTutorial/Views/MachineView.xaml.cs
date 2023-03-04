using MachinesTutorial.Model;
using MachinesTutorial.ViewModel;
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
    /// Interaction logic for MachineView.xaml
    /// </summary>
    public partial class MachineView : UserControl
    {
        public MachineView()
        {
            InitializeComponent();
          
        }
        private void TabControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left || e.Key == Key.Right)
            {
                int newIndex = -1;

                if (e.Key == Key.Left)
                {
                    newIndex = Math.Max(0, tabControl.SelectedIndex - 1);
                }
                else if (e.Key == Key.Right)
                {
                    newIndex = Math.Min(tabControl.Items.Count - 1, tabControl.SelectedIndex + 1);
                }

                if (newIndex != -1 && newIndex != tabControl.SelectedIndex)
                {
                    tabControl.SelectedIndex = newIndex;
                    e.Handled = true;
                }
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = tabControl.SelectedIndex - 1;
            if (newIndex < 0)
            {
                newIndex = tabControl.Items.Count - 1; // set index to the last tab
            }
            tabControl.SelectedIndex = newIndex;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = tabControl.SelectedIndex + 1;
            if (newIndex >= tabControl.Items.Count)
            {
                newIndex = 0; // set index to the first tab
            }
            tabControl.SelectedIndex = newIndex;
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl.SelectedIndex != null)
            {
                if (DataContext is MachineViewModel machine)
                {
                    machine.Machine.Progress = ((TabControl)sender).SelectedIndex + 1;
                }
            }
        }
    }
}
