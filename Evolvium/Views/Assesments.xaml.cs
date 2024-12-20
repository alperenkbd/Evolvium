﻿using Evolvium.Presentation.Views.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Evolvium.Presentation.Views
{
    /// <summary>
    /// Interaction logic for Assesments.xaml
    /// </summary>
    public partial class Assesments : Page
    {
        public Assesments()
        {
            InitializeComponent();
        }


        private void AddAssesment_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AssesmentsForm());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }

    
}
