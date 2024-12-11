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
    public class AssesmentsFormViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        public ObservableCollection<Degree> Degrees { get; set; } = new ObservableCollection<Degree>();
        public ObservableCollection<Module> Modules { get; set; } = new ObservableCollection<Module>();
        public Assesment CurrentAssessment { get; set; } = new Assesment();
        public RelayCommand LoadDegreesCommand { get; }
        public RelayCommand LoadModulesCommand { get; }
        public RelayCommand CreateAssesmentCommand { get; }
        public string DegreeId { get; set; }
        public string ModuleId { get; set; }
        public int CurrentScore { get; set; }

        public AssesmentsFormViewModel()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5218/")
            };
            LoadDegreesCommand = new RelayCommand(async _ => await LoadDegreesAsync());
            LoadModulesCommand = new RelayCommand(async _ => await LoadModulesAsync());
            CreateAssesmentCommand = new RelayCommand(async _ => await CreateAssesmentAsync());
            

        }

        private async Task LoadDegreesAsync()
        {
            try
            {
                var degrees = await _httpClient.GetFromJsonAsync<List<Degree>>("api/Degrees");
                if (degrees != null)
                {
                    Degrees?.Clear();
                    foreach (var degree in degrees)
                    {
                        Degrees?.Add(degree);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching degrees: {ex.Message}");
            }
        }

        private async Task LoadModulesAsync()
        {
            try
            {
                var modules = await _httpClient.GetFromJsonAsync<List<Module>>($"api/Modules/byDegree/{DegreeId}");
                if (modules != null)
                {
                    Modules?.Clear();
                    foreach (var module in modules)
                    {
                        Modules?.Add(module);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching modules: {ex.Message}");
            }
        }

        private async Task CreateAssesmentAsync()
        {
            CurrentAssessment.DegreeId = DegreeId;
            CurrentAssessment.ModuleId = ModuleId;
            CurrentAssessment.Score = CurrentScore;
            if (CurrentAssessment == null)
            {
                MessageBox.Show("Assessment cannot be null.");
                return;
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Assesments", CurrentAssessment);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Assessment successfully created.");
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to create assessment. Error: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while creating assessment: {ex.Message}");
            }
        }

    }
}
