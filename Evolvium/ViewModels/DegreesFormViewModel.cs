using Evolvium.Presentation.Commands;
using Evolvium.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Evolvium.Presentation.ViewModels
{
    public class DegreesFormViewModel: BaseViewModel
    {
        public Degree CurrentDegree { get; set; }
        public RelayCommand CreateCommand { get; }

        public DegreesFormViewModel()
        {
            CreateCommand = new RelayCommand(OnCreate);
        }


        private void OnCreate(object parameter)
        {
            // Form validasyon işlemleri

        }
    }
}
