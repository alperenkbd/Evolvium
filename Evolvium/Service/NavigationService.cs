using Evolvium.Presentation.Interface;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Evolvium.Presentation.Service
{
    public class NavigationService : INavigationService
    {
        public void NavigateTo(string pageName, object parameter = null)
        {
            var mainWindow = Application.Current.MainWindow;
            var frame = mainWindow.Content as Frame;

            if (frame != null)
            {
                var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

                var pageType = Type.GetType($"Evolvium.Presentation.Views.Form.{pageName}, Evolvium");


                if (pageType != null)
                {
                    var pageInstance = Activator.CreateInstance(pageType) as Page;
                    if (pageInstance != null)
                    {
                        frame.NavigationService.Navigate(pageInstance, parameter);
                    }
                    else
                    {
                        MessageBox.Show($"Page instance creation failed for {pageName}");
                    }
                }
                else
                {
                    MessageBox.Show($"Page type {pageName} not found in the assembly.");
                }
            }
            else
            {
                MessageBox.Show("Current window content is not a Frame.");
            }
        }
    }
}
