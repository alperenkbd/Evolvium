using Evolvium.Presentation.Commands;
using Evolvium.Presentation.Models;
using Evolvium.Presentation.Views;
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
    internal class AssesmentsViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        public ObservableCollection<Assesment> Assesments { get; set; } = new ObservableCollection<Assesment>();
        public RelayCommand LoadAssesmentsCommand { get; }



        public AssesmentsViewModel()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5218/")
            };


            LoadAssesmentsCommand = new RelayCommand(async _ => await LoadAssesmentsAsync());

            _ = LoadAssesmentsAsync();

        }


        private async Task LoadAssesmentsAsync()
        {
            try
            {
                var assesments = await _httpClient.GetFromJsonAsync<List<Assesment>>("api/Assesments");
                if (assesments != null)
                {
                    Assesments?.Clear();
                    foreach (var assesment in assesments)
                    {
                        Assesments.Add(assesment);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching assesments: {ex.Message}");
            }
        }


    }
}
