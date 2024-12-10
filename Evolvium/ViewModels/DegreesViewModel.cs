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

    internal class DegreesViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        public ObservableCollection<Degree> Degrees { get; set; } = new ObservableCollection<Degree>();
        public RelayCommand LoadDegreesCommand { get; }

        public RelayCommand EditCommand { get; }

        public DegreesViewModel()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5218/")
            };

            LoadDegreesCommand = new RelayCommand(async _ => await LoadDegreesAsync());

            _ = LoadDegreesAsync();

        }

        private async Task LoadDegreesAsync()
        {
            try
            {
                var degrees = await _httpClient.GetFromJsonAsync<List<Degree>>("api/Degrees");
                if (degrees != null)
                {
                    Degrees.Clear();
                    foreach (var degree in degrees)
                    {
                        Degrees.Add(degree);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching degrees: {ex.Message}");
            }
        }


    }

}
