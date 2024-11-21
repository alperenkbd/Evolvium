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
    internal class ModulesViewModel : BaseViewModel
    {

        public ObservableCollection<Module> Modules { get; set; }

        public RelayCommand EditCommand { get; }

        public ModulesViewModel()
        {
            Modules = new ObservableCollection<Module>
            {
                new Module { Number = "20224A127645", ModuleName = "Module 1", DegreeName = "Master's Degree", MaxScore = "100" }
            };

            EditCommand = new RelayCommand(OnEditModule);
        }

        private void OnEditModule(object parameter)
        {
            var module = parameter as Module;
            if (module != null)
            {
                MessageBox.Show($"Editing Module: {module.ModuleName}");
            }
        }
    }
}
