using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Week7.WPF.Esercizio2ECommerce.Models;
using Week7.WPF.Esercizio2ECommerce.ViewModels;
using Week7.WPF.Esercizio2ECommerce.Views;

namespace Week7.WPF.Esercizio2ECommerce
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IProductRepository productRepo = new MockProductRepository();
            MainWindowVM mwvm = new MainWindowVM(productRepo);
            MainWindow mainWindow = new MainWindow(mwvm);   //il DataContext gliel'ho collegato nel costruttore della MainWindowViewModel

            mainWindow.Show();
            
        }
    }
}
