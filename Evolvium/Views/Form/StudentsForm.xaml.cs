using Evolvium.Presentation.Models;
using Evolvium.Presentation.ViewModels;
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

namespace Evolvium.Presentation.Views.Form
{
    /// <summary>
    /// Interaction logic for StudentsForm.xaml
    /// </summary>
    public partial class StudentsForm : Page
    {
        public StudentsForm()
        {
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            var viewModel = DataContext as StudentFormViewModel;
            viewModel?.LoadDegreesCommand.Execute(null);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is Degree selectedDegree)
            {
                var viewModel = DataContext as StudentFormViewModel;
                if (viewModel != null)
                {
                    viewModel.CurrentStudent.DegreeId = selectedDegree.Id;
                }
            }
        }
    }
}
