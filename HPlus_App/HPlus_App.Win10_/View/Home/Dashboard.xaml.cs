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

namespace HPlus_App.Win10.View.Home
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void BtnJantung_Click(object sender, RoutedEventArgs e)
        {
            App.ViewRouting(false);
            App.ViewRouting(true, new Bahaya.JantungView());
        }

        private void BtnLambung_Click(object sender, RoutedEventArgs e)
        {
            App.ViewRouting(false);
            App.ViewRouting(true, new Biasa.LambungView());
        }

        private void BtnMata_Click(object sender, RoutedEventArgs e)
        {
            App.ViewRouting(false);
            App.ViewRouting(true, new Biasa.MataView());
        }
    

        private void BtnKelamin_Click(object sender, RoutedEventArgs e)
        {
            App.ViewRouting(false);
            App.ViewRouting(true, new Bahaya.KelaminView());
        }

        private void BtnTulang_Click(object sender, RoutedEventArgs e)
        {
            App.ViewRouting(false);
            App.ViewRouting(true, new Biasa.TulangView());
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MnuMata_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MnuLambung_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MnuTulang_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MnuKelamin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MnuJantung_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MnuDashboard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MnuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
