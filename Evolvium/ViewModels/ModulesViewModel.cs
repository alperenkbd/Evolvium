using Evolvium.Presentation.Commands;
using Evolvium.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Evolvium.Presentation.ViewModels
{
    internal class ModulesViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;

        public ObservableCollection<Module> Modules { get; set; }

        public RelayCommand EditCommand { get; }
        public RelayCommand LoadModulesCommand { get; }

        public ModulesViewModel()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5218/")
            };

            LoadModulesCommand = new RelayCommand(async _ => await LoadModulesAsync());

            _ = LoadModulesAsync();

            EditCommand = new RelayCommand(OnEditModule);
        }

        private async Task LoadModulesAsync()
        {
            try
            {
                var modules = await _httpClient.GetFromJsonAsync<List<Module>>("api/Modules");
                if (modules != null)
                {
                    Modules.Clear();
                    foreach (var module in modules)
                    {
                        Modules.Add(module);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching modules: {ex.Message}");
            }
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
