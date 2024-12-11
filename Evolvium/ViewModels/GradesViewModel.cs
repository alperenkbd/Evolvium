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
    public class GradesViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;

        public ObservableCollection<Grades> Grades { get; set; } = new ObservableCollection<Grades>();


        public RelayCommand LoadGradesCommand { get; }

        public GradesViewModel()
        {


            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5218/")
            };

            LoadGradesCommand = new RelayCommand(async _ => await LoadGradesAsync());

            _ = LoadGradesAsync();

        }

        private async Task LoadGradesAsync()
        {
            try
            {
                var grades = await _httpClient.GetFromJsonAsync<List<Grades>>("api/Grades");
                if (grades != null)
                {
                    Grades.Clear();
                    foreach (var grade in grades)
                    {
                        Grades.Add(grade);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching grades: {ex.Message}");
            }
        }
    }
}
