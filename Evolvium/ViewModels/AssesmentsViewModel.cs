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
    internal class AssesmentsViewModel : BaseViewModel
    {
        public ObservableCollection<Assesment> Assesment { get; set; }

        public RelayCommand EditCommand { get; }

        public AssesmentsViewModel()
        {
            Assesment = new ObservableCollection<Assesment>
            {
                new Assesment { Score=100 }
            };

            EditCommand = new RelayCommand(OnEditAssesment);
        }

        private void OnEditAssesment(object parameter)
        {
            var assesment = parameter as Assesment;
            if (assesment != null)
            {
                MessageBox.Show($"Editing Module: {assesment.AssesmentId}");
            }
        }
    }
}
