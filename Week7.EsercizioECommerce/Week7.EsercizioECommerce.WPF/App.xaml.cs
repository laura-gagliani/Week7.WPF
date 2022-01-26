using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Week7.EsercizioECommerce.Core.Mock.Repositories;
using Week7.EsercizioECommerce.Core.Mock.Storage;
using Week7.EsercizioECommerce.Core.Repositories;
using Week7.EsercizioECommerce.WPF.Messaging.Misc;
using Week7.EsercizioECommerce.WPF.ViewModels;
using Week7.EsercizioECommerce.WPF.Views;

namespace Week7.EsercizioECommerce.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Messenger.Default.Register<DialogMessage>(this, OnDialogMEssageReceived);


            MockStorage.Initialize();

            base.OnStartup(e);

            MainWindowVM mainVM = new MainWindowVM();
            MainWindow mainWindow = new MainWindow();  
            mainWindow.DataContext = mainVM;

            SignInWindow signInWindow = new SignInWindow(); //la view (l'ho chiamata window)
            SignInWindowVM signinVM = new SignInWindowVM();
            signInWindow.DataContext = signinVM;

            //signInWindow.Show();
            mainWindow.Show();



        }
        private void OnDialogMEssageReceived(DialogMessage message)
        {
            MessageBoxResult result = MessageBox.Show(message.Content, message.Title);

        }
    }
}
