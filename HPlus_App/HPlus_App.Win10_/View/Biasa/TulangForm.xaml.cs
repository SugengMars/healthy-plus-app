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
    /// Interaction logic for TulangForm.xaml
    /// </summary>
    public partial class TulangForm : Window
    {
        public TulangForm()
        {
            InitializeComponent();
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
