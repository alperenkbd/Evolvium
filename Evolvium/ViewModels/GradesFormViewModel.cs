using Evolvium.Presentation.Commands;
using Evolvium.Presentation.Models;
using Evolvium.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Evolvium.Presentation.ViewModels
{
    public  class GradesFormViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        public string GradeId { get; set; }
        public float CurrentGrade { get; set; }
        public RelayCommand UpdateGradeCommand { get; }

        public GradesFormViewModel()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5218/")
            };

            UpdateGradeCommand = new RelayCommand(async _ => await UpdateGradeAsync());
        }


        private async Task UpdateGradeAsync()
        {
            if (string.IsNullOrEmpty(GradeId))
            {
                MessageBox.Show("Grade ID is null or empty, cannot update.");
                return;
            }

            try
            {
                var response = await _httpClient.GetFromJsonAsync<Grades>($"api/Grades/{GradeId}");

                if (response != null)
                {
                    Grades _grade = response;

                    _grade.StudentGrade = CurrentGrade;

                    var putResponse = await _httpClient.PutAsJsonAsync($"api/Grades/{_grade.GradeId}", _grade);

                    if (putResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Grade updated successfully: {_grade.ModuleName}");
                    }
                    else
                    {
                        MessageBox.Show($"Failed to update grade. Status: {putResponse.StatusCode}");
                    }
                }
                else
                {
                    MessageBox.Show($"Grade with ID {GradeId} not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating grade: {ex.Message}");
            }
        }
    }
}
