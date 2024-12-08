using Evolvium.Presentation.Commands;
using Evolvium.Presentation.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace Evolvium.Presentation.ViewModels
{
    public class StudentFormViewModel : BaseViewModel
    {
        public Student CurrentStudent { get; set; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand CreateCommand { get; }

        private Action<Student> _onSaveCallback;
        public ICommand GoBackCommand { get; }

        public StudentFormViewModel()
        {
            SaveCommand = new RelayCommand(OnSave);
            CreateCommand = new RelayCommand(OnCreate);
        }

        private void OnSave(object parameter)
        {
            // Form validasyon işlemleri
            
        }

        private void OnCreate(object parameter)
        {
            // Form validasyon işlemleri

        }

    }
}
