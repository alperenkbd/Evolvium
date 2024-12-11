using Evolvium.Presentation.Interface;
using Evolvium.Presentation.Models;
using Evolvium.Presentation.ViewModels;
using Evolvium.Presentation.Views.Form;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Evolvium.Presentation.Service;
using System;
using System.Reflection;

namespace Evolvium.Presentation
{
    /// <summary>
    /// Interaction logic for Modules.xaml
    /// </summary>
    public partial class Modules : Page
    {


        public Modules()
        {
            InitializeComponent();

        }

        private void AddModule_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ModulesForm());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button != null)
            {
                var moduleId = button.CommandParameter;

                NavigationService.Navigate(new ModulesForm(moduleId.ToString()));

            }


        }

    }
}
