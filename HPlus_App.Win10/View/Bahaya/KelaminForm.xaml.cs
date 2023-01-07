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
namespace HPlus_App.Win10.View.Bahaya
{
    /// <summary>
    /// Interaction logic for KelaminForm.xaml
    /// </summary>
    public partial class KelaminForm : Window
    {
        public KelaminForm(KelaminViewModel vm)
        {
            InitializeComponent();
            if (vm.ModelKelamin == null)
            {
                vm.ModelKelamin = new Kelamin();
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
