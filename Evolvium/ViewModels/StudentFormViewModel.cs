using Evolvium.Presentation.Commands;
using Evolvium.Presentation.Models;
using System;
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
        public RelayCommand SaveCommand { get; }
        public RelayCommand CreateAStudentCommand { get; }

        private Action<Student> _onSaveCallback;

        public StudentFormViewModel()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5218/") 
            };

            SaveCommand = new RelayCommand(OnSave);
            CreateAStudentCommand = new RelayCommand(async _ => await CreateAStudentAsync());
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

        private void OnSave(object parameter)
        {
            // will be complated
        }


    }
}
