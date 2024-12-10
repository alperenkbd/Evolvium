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
        public RelayCommand CreateCommand { get; }
        public RelayCommand CreateAModuleCommand { get; }

        public ICommand GoBackCommand { get; }

        public ModulesFormViewModel()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5218/")
            };


            CreateAModuleCommand = new RelayCommand(async _ => await CreateAModuleAsync());
        }

        private async Task CreateAModuleAsync()
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Modules", CurrentModule);

                if (response.IsSuccessStatusCode)
                {
                    var createdModule = await response.Content.ReadFromJsonAsync<Module>();
                    if (createdModule != null)
                    {
                        MessageBox.Show("Module successfully created.");
                    }
                }
                else
                {
                    MessageBox.Show($"Failed to create module: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating module: {ex.Message}");
            }

        }
    }
}
