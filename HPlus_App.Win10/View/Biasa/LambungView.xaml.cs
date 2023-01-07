﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HPlus_App.Win10.ViewModels;
using System.Threading.Tasks;
namespace HPlus_App.Win10.View.Biasa
{
    /// <summary>
    /// Interaction logic for LambungView.xaml
    /// </summary>
    public partial class LambungView : UserControl
    {
        public LambungView()
        {
            InitializeComponent();
            vm = new LambungViewModel();
            vm.OnReload += () => {
                ListData.ItemsSource = null;
                ListData.ItemsSource = vm.DataLambung;
                if (form != null)
                {
                    form.Close();
                }
                vm.ModelLambung = null;
                BtnEdit.Visibility = Visibility.Hidden;
                BtnReset.Visibility = Visibility.Hidden;
            };
            DataContext = vm;
        }

        private LambungViewModel vm;
        private LambungForm form;

        private async Task InitFormAsync()
        {
            await Task.Delay(0);
            form = new LambungForm(vm);
            form.ShowDialog();
        }
        private async void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            vm.ModelLambung = null;
            await InitFormAsync();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.ViewRouting(false);
        }

        private async void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(0);
            vm.ModelLambung = null;
            BtnEdit.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Hidden;
        }

        private async void ListData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Task.Delay(0);
            if (vm.ModelLambung != null)
            {
                BtnEdit.Visibility = Visibility.Visible;
                BtnReset.Visibility = Visibility.Visible;
            }
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
