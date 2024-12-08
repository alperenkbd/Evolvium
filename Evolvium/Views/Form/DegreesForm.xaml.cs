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
    /// Interaction logic for DegreesForm.xaml
    /// </summary>
    public partial class DegreesForm : Page
    {
        public DegreesForm()
        {
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
