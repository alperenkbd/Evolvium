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
using System.Windows.Input;

namespace Evolvium.Presentation.ViewModels
{
    public class DegreesFormViewModel: BaseViewModel
    {
        private readonly HttpClient _httpClient;
        public ObservableCollection<int> DegreeLengths { get; set; } = new ObservableCollection<int> { 1, 2, 3 };
        public Degree CurrentDegree { get; set; } = new Degree();

        public RelayCommand CreateADegreeCommand { get; }

        public DegreesFormViewModel()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5218/")
            };

            CreateADegreeCommand = new RelayCommand(async _ => await CreateADegreeAsync());
        }


        private async Task CreateADegreeAsync()
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Degrees", CurrentDegree);

                if (response.IsSuccessStatusCode)
                {
                    var createdDegree = await response.Content.ReadFromJsonAsync<Degree>();
                    if (createdDegree != null)
                    {
                        MessageBox.Show("Degree and modules successfully created.");
                    }
                }
                else
                {
                    MessageBox.Show($"Failed to create degree: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating degree or modules: {ex.Message}");
            }
        }

    }
}
