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
    /// Interaction logic for ModulesForm.xaml
    /// </summary>
    public partial class ModulesForm : Page
    {
        string _moduleId;
        public ModulesForm(string moduleId = null)
        {
            InitializeComponent();
            _moduleId = moduleId;

            this.DataContext = new ModulesFormViewModel();
            var viewModel = this.DataContext as ModulesFormViewModel;
            if (viewModel != null)
            {
                viewModel.ModuleId = moduleId;
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
