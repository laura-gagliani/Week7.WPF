using Avanade.Allocation.Core.Mock.Storage;
using Avanade.Allocation.WPF.Messaging.Misc;
using Avanade.Allocation.WPF.ViewModels;
using Avanade.Allocation.WPF.Views;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Avanade.Allocation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //mi devo registrare agli eventi "invio messaggio di dialogo"
            //mi metto in ascolto di eventuali messaggi "DialogMessage"
            Messenger.Default.Register<DialogMessage>(this, OnDialogMessageReceived);




            //inizializziamo il MockDB (visto che abbiamo avviato la lista in un metodo!)
            AllocationMockStorage.Initialize();

            //inizializzo la view di login
            SignInView signinView = new SignInView();

            //inizializzo il VM associato a tale view
            SignInViewModel signinVM = new SignInViewModel();

            //collego il viewmodel alla view -> datacontext
            signinView.DataContext = signinVM;

            //mostro la view
            signinView.Show();


            base.OnStartup(e);



        }

        private void OnShutDownApplicationMessageReceived(ShutDownApplicationMessage quitMessage)
        {
            

        }

        //metodo che scatta quando arriva un qualsiasi messaggio di tipo DialogMessage
        private void OnDialogMessageReceived(DialogMessage message)
        {
            MessageBoxResult result = MessageBox.Show(message.Content, message.Title, message.Buttons, message.Icon);
            
        }
    }
}
