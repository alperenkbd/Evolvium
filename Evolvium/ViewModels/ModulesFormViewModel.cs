using Evolvium.Presentation.Commands;
using Evolvium.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Evolvium.Presentation.ViewModels
{
    public class ModulesFormViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        public Module CurrentModule { get; set; }
        public RelayCommand UpdateModuleCommand { get; }

        public ICommand GoBackCommand { get; }
        public string ModuleId { get; set; }
        public string CurrentModuleName { get; set; }

        public ModulesFormViewModel()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5218/")
            };


            UpdateModuleCommand = new RelayCommand(async _ => await UpdateModuleAsync());
        }

        private async Task UpdateModuleAsync()
        {
            if (string.IsNullOrEmpty(ModuleId))
            {
                MessageBox.Show("Module ID is null or empty, cannot update.");
                return;
            }

            try
            {
                var response = await _httpClient.GetFromJsonAsync<Module>($"api/Modules/{ModuleId}");

                if (response != null)
                {
                    Module _module = response;

                    _module.ModuleName= CurrentModuleName;

                    var putResponse = await _httpClient.PutAsJsonAsync($"api/Modules/{_module.Id}", _module);

                    if (putResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Module updated successfully: {_module.ModuleName}");
                    }
                    else
                    {
                        MessageBox.Show($"Failed to update module. Status: {putResponse.StatusCode}");
                    }
                }
                else
                {
                    MessageBox.Show($"Module with ID {ModuleId} not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating module: {ex.Message}");
            }
        }

    }
}
