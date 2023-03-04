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
    /// Interaction logic for QuizView.xaml
    /// </summary>
    public partial class QuizView : UserControl
    {
        public QuizView()
        {
            InitializeComponent();
            NextBtn.IsEnabled= false;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton != null)
            {
                
                var selectedChoice = (QuizChoice)radioButton.DataContext;
                selectedChoice.QuizQuestion.CurrentChoice = Convert.ToInt32(radioButton.Tag);
                NextBtn.IsEnabled = true;
            }
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            
            int nextIndex = MainTabControl.SelectedIndex + 1;
            if (nextIndex <= MainTabControl.Items.Count)
            {
                MainTabControl.SelectedIndex = nextIndex;
                if (nextIndex + 1 == MainTabControl.Items.Count + 1)
                {
                    var Vm = (QuizViewModel)this.DataContext;
                    Vm.GoToResultView();
                }
                NextBtn.IsEnabled = false;
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            int prevIndex = MainTabControl.SelectedIndex - 1;
            if (prevIndex >= 0)
            {
                MainTabControl.SelectedIndex = prevIndex;
                NextBtn.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            MessageBoxResult result = MessageBox.Show("Are you sure you want to go back to the home screen if you do all progress will be lost!","Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                 var Vm = (QuizViewModel)this.DataContext;
                 Vm.GoToHomeView();
            }
            
        }

        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainTabControl.SelectedItem != null)
            {
                QuizQuestion question = (QuizQuestion)MainTabControl.SelectedItem;
                var Vm = (QuizViewModel)this.DataContext;
                Vm.CheckQuestionType(question.Id);
            }
        }
    }
}
