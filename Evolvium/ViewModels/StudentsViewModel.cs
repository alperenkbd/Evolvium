using Evolvium.Presentation.Commands;
using Evolvium.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Evolvium.Presentation.ViewModels
{
    internal class StudentsViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;

        public ObservableCollection<Student> Students { get; set; }
        public RelayCommand EditCommand { get; }
        public RelayCommand LoadStudentsCommand { get; }
        

        public StudentsViewModel()
        {
            
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5218/")
            };

            Students = new ObservableCollection<Student>();
            EditCommand = new RelayCommand(OnEditStudent);
            LoadStudentsCommand = new RelayCommand(async _ => await LoadStudentsAsync());

            _ = LoadStudentsAsync();
        }

        private async Task LoadStudentsAsync()
        {
            try
            {
                var students = await _httpClient.GetFromJsonAsync<List<Student>>("api/Students");
                if (students != null)
                {
                    Students.Clear();
                    foreach (var student in students)
                    {
                        Students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching students: {ex.Message}");
            }
        }

        

        private void OnEditStudent(object parameter)
        {
            var student = parameter as Student;
            if (student != null)
            {
                MessageBox.Show($"Editing Module: ");
            }
        }
    }
}
