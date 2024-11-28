using Evolvium.Presentation.Commands;
using Evolvium.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Evolvium.Presentation.ViewModels
{
    internal class StudentsViewModel : BaseViewModel
    {
        public ObservableCollection<Student> Student { get; set; }

        public RelayCommand EditCommand { get; }

        public StudentsViewModel()
        {
            Student = new ObservableCollection<Student>
            {
                new Student {  Name= "John", Surname = "Alison", Degree= "1 year degree", Number = "100",Year = "1999" }
            };

            EditCommand = new RelayCommand(OnEditStudent);
        }

        private void OnEditStudent(object parameter)
        {
            var student = parameter as Student;
            if (student != null)
            {
                MessageBox.Show($"Editing Module: {student.Number}");
            }
        }
    }
}
