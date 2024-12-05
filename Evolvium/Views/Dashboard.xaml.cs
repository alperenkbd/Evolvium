using Evolvium.Presentation.Views;
using System.Windows;
using System.Windows.Controls;

namespace Evolvium.Presentation
{
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
            this.SizeChanged += Dashboard_SizeChanged;
            UpdateMenuVisibility();
        }

        private void Dashboard_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateMenuVisibility();
        }

        private void UpdateMenuVisibility()
        {
            if (this.ActualWidth < 600) // 
            {
                MenuPanel.Visibility = Visibility.Collapsed;
                MenuButton.Visibility = Visibility.Visible;
            }
            else
            {
                MenuPanel.Visibility = Visibility.Visible;
                MenuButton.Visibility = Visibility.Collapsed;
            }
        }

        private void ShowMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPanel.Visibility = Visibility.Visible;
            MenuButton.Visibility = Visibility.Collapsed;
        }

        private void HideMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPanel.Visibility = Visibility.Collapsed;
            MenuButton.Visibility = Visibility.Visible;
        }

        private void NavigateToStudents(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Students());
        }

        private void NavigateToModules(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Modules());
        }

        private void NavigateToDegrees(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Degrees());
        }

        private void NavigateToAssesments(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Assesments());
        }

        private void Logout(object sender, RoutedEventArgs e)
        {

        }
    }
}
