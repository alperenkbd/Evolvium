using Evolvium.Presentation.Commands;
using Evolvium.Presentation.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Input;

namespace Evolvium.Presentation.ViewModels
{
    public class StudentFormViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        public Student CurrentStudent { get; set; } = new Student();
        public ObservableCollection<Degree> Degrees { get; set; } = new ObservableCollection<Degree>();
        public RelayCommand SaveCommand { get; }
        public RelayCommand CreateAStudentCommand { get; }
        public RelayCommand LoadDegreesCommand { get; }

        private Action<Student> _onSaveCallback;

        public StudentFormViewModel()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5218/") 
            };

            SaveCommand = new RelayCommand(OnSave);
            LoadDegreesCommand = new RelayCommand(async _ => await LoadDegreesAsync());
            CreateAStudentCommand = new RelayCommand(async _ => await CreateAStudentAsync());
        }

        public Degree SelectedDegree
        {
            get => Degrees.FirstOrDefault(d => d.Id == CurrentStudent.DegreeId);
            set
            {
                if (value != null)
                {
                    CurrentStudent.DegreeId = value.Id;
                }
            }
        }


        private async Task CreateAStudentAsync()
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Students", CurrentStudent);

                if (response.IsSuccessStatusCode)
                {
                    var createdStudent = await response.Content.ReadFromJsonAsync<Student>();
                    if (createdStudent != null)
                    {
                        MessageBox.Show("Student successfully created.");
                    }
                }
                else
                {
                    MessageBox.Show($"Failed to create student: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating student: {ex.Message}");
            }
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

        private void OnSave(object parameter)
        {
            // will be complated
        }


    }
}
