
using Evolvium.Presentation.Models;
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

            StudentsGrid.ItemsSource = new List<Student>
            {
                new Student { Number = "20224A127645", Name = "John", 
                    Surname = "Sparrow", Degree = "2",Year = "2024-2025" },
                
            };
        }


        private void AddModule_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add Module functionality to be implemented.");
        }


        
    }

}
