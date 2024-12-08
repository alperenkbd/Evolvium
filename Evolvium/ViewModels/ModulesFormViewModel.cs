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
    public class ModulesFormViewModel : BaseViewModel
    {
        public Module CurrentModule { get; set; }
        public RelayCommand CreateCommand { get; }

        public ICommand GoBackCommand { get; }

        public ModulesFormViewModel()
        {
            CreateCommand = new RelayCommand(OnCreate);
        }

        private void OnCreate(object parameter)
        {
            // Form validasyon işlemleri

        }
    }
}
