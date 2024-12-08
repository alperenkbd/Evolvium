
using Evolvium.Presentation.Models;
using Evolvium.Presentation.ViewModels;
using Evolvium.Presentation.Views;
using Evolvium.Presentation.Views.Form;
using System.Windows;
using System.Windows.Controls;


namespace Evolvium.Presentation
{
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : Page
    {
        public Students()
        {
            InitializeComponent();

        }


        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentsForm());
        }


        
    }

}
