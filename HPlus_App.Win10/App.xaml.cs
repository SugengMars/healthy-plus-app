using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HPlus_App.Win10.View.Home;
using System.Windows.Controls;
using HPlus_App.Win10.Models;

namespace HPlus_App.Win10
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Dashboard view { get; set; }
        public static void ViewRouting(bool flag, Control content = null)
        {
            if (flag == true)
            {
                view.PnlContent.Children.Add(content);
            }
            else
            {
                view.PnlContent.Children.Clear();
            }
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            view = new Dashboard();
            view.Show();

        }
    }
}
