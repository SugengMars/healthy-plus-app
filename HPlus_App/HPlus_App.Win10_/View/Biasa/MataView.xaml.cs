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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HPlus_App.Win10.ViewModels;
using System.Threading.Tasks;
namespace HPlus_App.Win10.View.Biasa
{
    /// <summary>
    /// Interaction logic for MataView.xaml
    /// </summary>
    public partial class MataView : UserControl
    {
        public MataView()
        {
            InitializeComponent();
            vm = new MataViewModel();
            vm.OnReload += () => {
                ListData.ItemsSource = null;
                ListData.ItemsSource = vm.DataMata;
                if (form != null)
                {
                    form.Close();
                }
                vm.ModelMata = null;
                BtnEdit.Visibility = Visibility.Hidden;
                BtnReset.Visibility = Visibility.Hidden;
            };
            DataContext = vm;
        }

        private MataViewModel vm;
        private MataForm form;

        private async Task InitFormAsync()
        {
            await Task.Delay(0);
            form = new MataForm(vm);
            form.ShowDialog();
        }
        private async void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            vm.ModelMata = null;
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
            vm.ModelMata = null;
            BtnEdit.Visibility = Visibility.Hidden;
            BtnReset.Visibility = Visibility.Hidden;
        }

        private async void ListData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Task.Delay(0);
            if (vm.ModelMata != null)
            {
                BtnEdit.Visibility = Visibility.Visible;
                BtnReset.Visibility = Visibility.Visible;
            }
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            vm.ModelMata = null;
            await InitFormAsync();
        }
    }
}
