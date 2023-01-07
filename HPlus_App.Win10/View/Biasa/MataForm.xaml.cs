using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HPlus_App.Win10.ViewModels;
using HPlus_App.Win10.Models;

namespace HPlus_App.Win10.View.Biasa
{
    /// <summary>
    /// Interaction logic for MataForm.xaml
    /// </summary>
    public partial class MataForm : Window
    {
        public MataForm(MataViewModel vm)
        {
            InitializeComponent();
            if (vm.ModelMata == null)
            {
                vm.ModelMata = new Mata();
                BtnDelete.Visibility = Visibility.Hidden;
                BtnUpdate.Visibility = Visibility.Hidden;
                BtnSave.Visibility = Visibility.Visible;
            }
            else
            {
                BtnDelete.Visibility = Visibility.Visible;
                BtnUpdate.Visibility = Visibility.Visible;
                BtnSave.Visibility = Visibility.Hidden;
            }
            DataContext = vm;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
