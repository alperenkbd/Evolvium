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

    internal class DegreesViewModel : BaseViewModel
    {
        public ObservableCollection<Degree> Degree { get; set; }

        public RelayCommand EditCommand { get; }

        public DegreesViewModel()
        {
            Degree = new ObservableCollection<Degree>
            {
                new Degree {  Number = "msc435454",Name= "Master's Degree", LengthOfDegree = 1}
            };

            EditCommand = new RelayCommand(OnEditDegree);
        }

        private void OnEditDegree(object parameter)
        {
            var degree = parameter as Degree;
            if (degree != null)
            {
                MessageBox.Show($"Editing Module: {degree.Number}");
            }
        }
    }

}
